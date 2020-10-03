using DotnetSpider;
using DotnetSpider.DataFlow;
using DotnetSpider.DataFlow.Parser;
using DotnetSpider.DataFlow.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderStudy
{
    public class GithubSpider : Spider
    {
        public GithubSpider(IOptions<SpiderOptions> options, SpiderServices services, ILogger<Spider> logger) : base(
            options, services, logger)
        {
        }

        protected override async Task InitializeAsync(CancellationToken stoppingToken)
        {
            // 添加自定义解析
            AddDataFlow(new Parser());
            // 使用控制台存储器
            AddDataFlow(new ConsoleStorage());
            // 添加采集请求
            await AddRequestsAsync("https://github.com/zlzforever");
        }

        protected override (string Id, string Name) GetIdAndName()
        {
            return (Guid.NewGuid().ToString("N"), "Github");
        }

        class Parser : DataParser
        {
            protected override Task Parse(DataContext context)
            {
                var selectable = context.Selectable;
                // 解析数据
                var author = selectable.XPath("//span[@class='p-name vcard-fullname d-block overflow-hidden']")
                    ?.Value;
                var name = selectable.XPath("//span[@class='p-nickname vcard-username d-block']")
                    ?.Value;
                context.AddData("author", author);
                context.AddData("username", name);
                return Task.CompletedTask;
            }
        }
    }
}
