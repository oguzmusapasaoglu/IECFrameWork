using Microsoft.Extensions.Configuration;

using System;

namespace IFW.Configrations
{
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public static IECFWAppConfiguration GetIFWAppConfiguration()
        {
            string name = "ICFlowerAppConfiguration";
            var settings = GetConfig();

            if (settings.GetSection(name).Exists())
                return settings.GetSection(name).Get<IECFWAppConfiguration>();
            return null;
        }
    }
}
