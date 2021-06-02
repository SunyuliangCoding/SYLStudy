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
        private static ClassA ClassA = new ClassA();
        private static ClassB ClassB = new ClassB();
        static void Main(string[] args)
        {
            Console.WriteLine("开始");

            List<int> listA = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                listA.Add(i);
            }
            Parallel.ForEach(listA, p =>
            {
                testLockBLockA();
                testLockALockB();
            });


            Console.WriteLine("完成");
            Console.ReadKey();
        }
        public static void testLockALockB()
        {
            lock (ClassA)
            {
                Console.WriteLine("lock a");
                lock (ClassB)
                {
                    Console.WriteLine("lock b");
                }
            }
        }


        public static void testLockBLockA()
        {
            lock (ClassB)
            {
                Console.WriteLine("lock b");
                lock (ClassA)
                {
                    Console.WriteLine("lock a");
                }
            }
        }

    }

    public class ClassA
    {

    }
    public class ClassB
    {

    }

    class info
    {
        public static List<string> infoList = new List<string>();

        public static void testErr(int strart)
        {
            infoList.Clear();
            for (int i = strart; i < 1000; i++)
            {
                infoList.Add(i.ToString());
                Console.WriteLine(i);
            }

        }
    }
}
