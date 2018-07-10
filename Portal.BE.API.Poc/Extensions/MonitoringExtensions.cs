using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Portal.BE.API.Poc.Extensions
{
    public static class MonitoringExtensions
    {
        public static void UseMonitoring(this ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            loggerFactory.AddSerilog();
            loggerFactory.AddApplicationInsights(
                configuration.GetSection("Logging"),
                configuration.GetSection("ApplicationInsights")
            );
        }
    }
}
