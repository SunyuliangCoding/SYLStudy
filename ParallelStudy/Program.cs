using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelStudy
{
    class Program
    {
        static void Main(string[] args)
        {
           // ForEachAndForAll.TestForAll(30);
           // ForEachAndForAll.TestForEach();
            ForEachAndForAll.TestForAll(10);
            ForEachAndForAll.TestForAllNoLimit();
            Console.WriteLine("操作完成");
            Console.ReadKey();

        }
    }
}
