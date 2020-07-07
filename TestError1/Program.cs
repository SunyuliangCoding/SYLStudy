using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestError1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始");
            Thread.Sleep(1000);
            var a = 0;
            var b = 239 / a;
            List<int> testList = new List<int>();
            ConcurrentBag<Task> tList = new ConcurrentBag<Task>();
            for (int i = 0; i < 10000; i++)
            {
                var t = Task.Run(() =>
                  {
                      testList.Add(i);
                      testList.Add(i);
                      testList.Add(i);
                  });
                tList.Add(t);
            }
            Task.WaitAll(tList.ToArray());
            Console.WriteLine("完成");
            Console.ReadKey();
        }
    }
}
