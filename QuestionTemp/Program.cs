using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "aaa";
            var str2 = str1;
            str2 += "bbb";
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.ReadKey();
        }
    }
}
