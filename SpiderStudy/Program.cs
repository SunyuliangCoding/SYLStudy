using DotnetSpider.Scheduler.Component;
using System;
using System.Threading.Tasks;
using DotnetSpider;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Hosting;

namespace SpiderStudy
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console().WriteTo.RollingFile("logs/spiders.log")
                .CreateLogger();


            var builder = Builder.CreateDefaultBuilder<GithubSpider>(options =>
            {
                // 每秒 1 个请求
                options.Speed = 1;
                // 请求超时
                options.RequestTimeout = 10;
            });
            builder.UseSerilog();
            builder.UseQueueDistinctBfsScheduler<HashSetDuplicateRemover>();
            await builder.Build().RunAsync();
            Environment.Exit(0);
        }
    }
}
