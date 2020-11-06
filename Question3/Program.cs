using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    class Program
    {
        //静态构造函数抛异常会导致类坏死
        static void Main(string[] args)
        {

            try
            {
                var x = UserProvider.Instance;

            }
            catch (Exception ex)
            {

            }
            try
            {
                throwex.doit = false;
                var x = UserProvider.Instance;
            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
    public static class throwex
    {
        public static bool doit = true;
    }

    public class UserProvider
    {
        private static readonly UserProvider _instance;
        public static UserProvider Instance
        {
            get { return _instance; }
        }
        static UserProvider()
        {
            if (throwex.doit)
            {
                throw new Exception();

            }
            _instance = new UserProvider();
        }
    }
}
