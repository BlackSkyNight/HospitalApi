using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace PrNotifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog((context, loggerConfig) =>
                    {
                        var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
                        telemetryConfiguration.InstrumentationKey = context.Configuration["ApplicationInsights:InstrumentationKey"];

                        loggerConfig.ReadFrom.Configuration(context.Configuration);
                        loggerConfig.WriteTo.ApplicationInsights(telemetryConfiguration, TelemetryConverter.Traces);

                        if (context.HostingEnvironment.IsDevelopment())
                            loggerConfig.WriteTo.Console();

                        loggerConfig.WriteTo.File(@"Logs\log_notifications.txt", rollingInterval: RollingInterval.Day);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
