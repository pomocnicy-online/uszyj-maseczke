using System;
using System.Net;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UszyjMaseczke.WebApi
{
    public class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            try
            {
                return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseIISIntegration();
                        webBuilder.UseUrls("http://*:5011");
                        webBuilder.ConfigureAppConfiguration((builderContext, config) =>
                        {
                            config.AddJsonFile("appsettings.json", false, true)
                                .AddEnvironmentVariables();
                        });
                        webBuilder.ConfigureKestrel(options =>
                        {
                            options.Limits.MaxConcurrentConnections = 100;
                            options.Limits.MaxConcurrentUpgradedConnections = 100;
                            options.Limits.MaxRequestBodySize = 10 * 1000 * 1024;
                            options.Limits.MinRequestBodyDataRate =
                                new MinDataRate(100, TimeSpan.FromSeconds(10));
                            options.Limits.MinResponseDataRate =
                                new MinDataRate(100, TimeSpan.FromSeconds(10));
                            options.Listen(IPAddress.Any, 5011);
                        });
                        webBuilder.UseStartup<Startup>();
                    });
            }
            catch (Exception e)
            {
                Logger.Error("Error while creating host builder");
                Logger.Error(e.StackTrace);
                throw e;
            }
        }
    }
}