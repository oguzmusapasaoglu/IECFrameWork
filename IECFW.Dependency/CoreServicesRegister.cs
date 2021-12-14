
using IFW.Configrations;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Text;
using System.Threading.Tasks;

namespace IFW.Dependency
{
    public static class CoreServicesRegister
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddCors();
            // https://docs.microsoft.com/tr-tr/aspnet/core/security/anti-request-forgery?view=aspnetcore-5.0
            services.AddAntiforgery(options =>
            {
                options.FormFieldName = "AntiforgeryToken";
                options.HeaderName = "X-CSRF-TOKEN-HEADER";
                options.SuppressXFrameOptionsHeader = false;
            });

            services.AddMemoryCache();
            services.AddEntityFrameworkNpgsql();
            var appSettingsSection = configuration.GetSection(nameof(IECFWAppConfiguration));
            var iCFlowerAppConfiguration = appSettingsSection.Get<IECFWAppConfiguration>();
            services.AddSingleton(iCFlowerAppConfiguration);
            var secretKey = Encoding.ASCII.GetBytes(iCFlowerAppConfiguration.ApplicationSecurity.JWTTokenSecretKey);
            //services.UseNpgsql(iCFlowerAppConfiguration.PostgreConnString);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = "ICFlower",
                    ValidateIssuer = true,
                    ValidIssuer = "ICFlowerUser",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                };

                token.Events = new JwtBearerEvents
                {
                    OnTokenValidated = ctx =>
                    {
                        // If needed we can make some extra validation for values which is inside of token
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = ctx =>
                    {
                        if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            ctx.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    },
                    OnChallenge = ctx =>
                    {
                        if (ctx?.AuthenticateFailure is SecurityTokenExpiredException)
                        {
                            var error = ctx.Error; // "invalid_token"
                            var errorDescription = ctx.ErrorDescription; // "The token is expired"
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
