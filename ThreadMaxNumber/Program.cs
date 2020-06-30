using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadMaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //目前看来创建线程是没有限制的，但是线程池目前存量用完后，需要真正创建新线程，速度还是比较慢的。
            for (int i = 0; i < 100; i++)
            {
                Task.Run(()=> {
                    Console.WriteLine($"threadID={Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(10000000);
                });
            }
            Console.WriteLine("完成");
            Console.ReadKey();
        }
    }
}
