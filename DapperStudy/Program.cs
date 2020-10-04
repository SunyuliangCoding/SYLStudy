using System;

namespace DapperStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NewsInsertTest();
        }
        public static void NewsInsertTest()
        {
            var news = new NewsEntity()
            {
                Category = "a",
                CreationTime = DateTime.Now,
                Guid = Guid.NewGuid().ToString(),
                Id = 1,
                News = "测试",
                PlainText = "测试text",
                Title = "测试title",
                Url = "sdfafd",
                WebSite = "asdfasdf"
            };
            NewsDb.Insert(news);
        }

    }
}
