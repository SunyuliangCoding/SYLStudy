using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelStudy
{
    public class ForeachAndStaticFunc
    {
        public static void TestStaticFunc()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            Parallel.ForEach(list, p =>
            {
                RunFunc.Instance.func1(p);
            });

            var result = RunFunc.Instance.intList.OrderBy(p => p).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class RunFunc
    {
        private static readonly RunFunc _instance = new RunFunc();
        public ConcurrentBag<int> intList = new ConcurrentBag<int>();
        public static RunFunc Instance
        {
            get
            {
                return _instance;
            }
        }
        public void func1(int i)
        {
            intList.Add(i);
        }

    }
}
