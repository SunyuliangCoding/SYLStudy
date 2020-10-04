using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DapperStudy
{
    public class NewsEntity
    {


        public int Id { get; set; }

        public string Category { get; set; }

        public string WebSite { get; set; }

        public string Title { get; set; }

        public string Guid { get; set; }


        public string News { get; set; }


        public string Url { get; set; }

        public string PlainText { get; set; }

        public DateTime CreationTime { get; set; }
    }

    public class NewsDb
    {
        private static string conStr = "Data Source=127.0.0.1;Initial Catalog=SpiderTest;Integrated Security=False;Max Pool Size = 512;User ID=admin;Password=admin;Connect Timeout=120;Packet Size=4096;";
        public static int Insert(NewsEntity news)
        {
            using (IDbConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute("insert into news(Id,Category,WebSite,Title,Guid,News,Url,PlainText,CreationTime) values(@Id,@Category,@WebSite,@Title,@Guid,@News,@Url,@PlainText,@CreationTime)", news);
            }
        }
        public static List<NewsDb> Get()
        {
            return null;
        }
    }
}
