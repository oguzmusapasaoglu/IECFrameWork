using IECFW.Common.Helper;
using IECFW.ExceptionHandling;

using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace IECFW.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionMiddleware>();
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(KnownException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, KnownException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            //Log.LogError($"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                ExceptionTypeStr = ex.ExceptionType.ToString(),
                MethotName=ex.MethotName,
                StackTrace=ex.StackTrace,
                Message = ex.Message
            }.ToString());
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            //Log.LogError($"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                ExceptionTypeStr = ExceptionTypeEnum.Fattal.ToString(),
                StackTrace = ex.StackTrace,
                Message = ex.Message
            }.ToString());
        }
    }
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
