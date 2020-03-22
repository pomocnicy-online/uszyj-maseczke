using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UszyjMaseczke.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();
                    webBuilder.UseUrls("http://*:5011");
                    webBuilder.ConfigureAppConfiguration((builderContext, config) =>
                    {
                        config.AddJsonFile("appsettings.Development.json", false, true)
                            .AddJsonFile("appsettings.json", false, true)
                            .AddEnvironmentVariables();
                    });
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Limits.MaxConcurrentConnections = 100;
                        options.Limits.MaxConcurrentUpgradedConnections = 100;
                        options.Limits.MaxRequestBodySize = 10 * 1000 * 1024;
                        // 52428800
                        options.Limits.MinRequestBodyDataRate =
                            new MinDataRate(100, TimeSpan.FromSeconds(10));
                        options.Limits.MinResponseDataRate =
                            new MinDataRate(100, TimeSpan.FromSeconds(10));
                        options.Listen(IPAddress.Any, 5011);
                    });
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}