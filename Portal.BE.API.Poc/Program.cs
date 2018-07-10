using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace Portal.BE.API.Poc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create Singleton Instance of Serilog
            CreateLogger();

            // Trace Startup
            try
            {
                Log.Information(string.Format("Starting up {0}", "Portal.BE.API.Poc"));
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Startup failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // Get a builder instance of the webhost
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        // Create a singleton instance of Serilog to Application Insights
        public static void CreateLogger() => Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ApplicationInsightsEvents("aa767e69-2328-445c-84ea-bdcd16d7b2d5")
                .CreateLogger();
    }
}
