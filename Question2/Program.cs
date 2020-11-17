using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            //这里有点问题，跑了很久没抛异常
            List<int> list = new List<int>();
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 80; i++)
            {
              var t=  Task.Run(()=> {
                    for (int j = 0; j < 100; j++)
                    {
                        list.Add(j);
                    }
                  throw new Exception();
                });
                taskList.Add(t);
            }
            Task.WaitAll(taskList.ToArray());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("结束");
            Console.ReadKey();

        }
    }
}
