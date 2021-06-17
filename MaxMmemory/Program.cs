using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMmemory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < int.MaxValue; i++)
            {
                list.Add(string.Join(",", Enumerable.Range(0, 10000)));
            }

            Console.ReadLine();
        }

    }
}
