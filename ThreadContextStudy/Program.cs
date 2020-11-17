using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadContextStudy
{
    class Program
    {

        static void Main(string[] args)
        {
            CallContext.LogicalSetData("key1", "value1");
            CallContext.SetData("key2", "value2");

            Task.Run(() =>
            {
                var value1 = CallContext.LogicalGetData("key1");
                var value2 = CallContext.GetData("key2");
                Console.WriteLine($"value1:{value1},value2:{value2}");
            });

            Console.ReadKey();
        }
    }
}
