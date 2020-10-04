using Dapper;
using DotnetSpider.DataFlow;
using DotnetSpider.DataFlow.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static SpiderEntityConfig.EntitySpider;

namespace SpiderEntityConfig
{
    public class NewsDb: StorageBase
    {
        private static string conStr = "Data Source=127.0.0.1;Initial Catalog=SpiderTest;Integrated Security=False;Max Pool Size = 512;User ID=admin;Password=admin;Connect Timeout=120;Packet Size=4096;";
        public static int Insert(NewsEntity news)
        {
            using (IDbConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute("insert into news(Category,WebSite,Title,Guid,News,Url,PlainText,CreationTime) values(@Category,@WebSite,@Title,@Guid,@News,@Url,@PlainText,@CreationTime)", news);
            }
        }
        public static IDataFlow CreateFromOptions(IConfiguration configuration)
        {
            return new NewsDb();
        }
        public static List<NewsDb> Get()
        {
            return null;
        }

        protected override Task StoreAsync(DataContext context)
        {
            var items = context.GetData();
            foreach (var item in items)
            {
                var type = item.Key as Type;
                if (type==null)
                {
                    continue;
                }
                if (item.Value is System.Collections.IEnumerable list)
                {
                    foreach (var newItem in list)
                    {
                        NewsDb.Insert(newItem as NewsEntity);
                    }
                }
                else
                {
                    NewsDb.Insert(item.Value);
                }
            }
            if (items.ContainsKey(nameof(NewsEntity)))
            {
                var entiyList = items[nameof(NewsEntity)];
                foreach (var item in entiyList)
                {
                    NewsDb.Insert(item);
                }
            }
            return Task.CompletedTask;
        }
    }
}
