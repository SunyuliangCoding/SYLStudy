using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelStudy
{
    //设置并行数目并不会超过13-14，在6核12线程的情况下
    public static class ForEachAndForAll
    {
        public static ConcurrentDictionary<int, int> threadDic;

        public static List<int> source = new List<int>();
        static ForEachAndForAll()
        {
            for (int i = 0; i < 4000; i++)
            {
                source.Add(i);
            }
        }

        public static void TestForEach(int maxThread = 5)
        {
            var option = new ParallelOptions
            {
                MaxDegreeOfParallelism = maxThread
            };
            threadDic = new ConcurrentDictionary<int, int>();
            Console.WriteLine($"test foreach,count ={source.Count}, 并行数量={option.MaxDegreeOfParallelism}");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine();
            Parallel.ForEach(source, p =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                if (threadDic.ContainsKey(id))
                {
                    threadDic[id]++;
                }
                else
                {
                    threadDic.TryAdd(id, 1);
                }

                //        Console.WriteLine(p);
                Thread.Sleep(200);
            });
            sw.Stop();
            Console.WriteLine($"使用线程={threadDic.Count},消耗时间为={sw.ElapsedMilliseconds}");
        }
        public static void TestForAll(int maxThread = 5)
        {

            threadDic = new ConcurrentDictionary<int, int>();
            Console.WriteLine($"test forall,count ={source.Count}, 并行数量={maxThread}");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            source.AsParallel().WithDegreeOfParallelism(maxThread).ForAll(p =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                if (threadDic.ContainsKey(id))
                {
                    threadDic[id]++;
                }
                else
                {
                    threadDic.TryAdd(id, 1);
                }

                //       Console.WriteLine(p);
                Thread.Sleep(200);
            });
            sw.Stop();
            Console.WriteLine($"使用线程={threadDic.Count},消耗时间为={sw.ElapsedMilliseconds}");
        }
        public static void TestForAllNoLimit()
        {

            threadDic = new ConcurrentDictionary<int, int>();
            Console.WriteLine($"test forall,count ={source.Count}");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            source.AsParallel().ForAll(p =>
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                if (threadDic.ContainsKey(id))
                {
                    threadDic[id]++;
                }
                else
                {
                    threadDic.TryAdd(id, 1);
                }

                //       Console.WriteLine(p);
                Thread.Sleep(200);
            });
            sw.Stop();
            Console.WriteLine($"使用线程={threadDic.Count},消耗时间为={sw.ElapsedMilliseconds}");
        }
    }
}
