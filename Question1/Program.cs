using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo.PrintUserInfo();
            Console.WriteLine("结束");
            Console.ReadKey();
        }
    }
    public class UserInfo
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _email;
        

        public int id { get { return _id; } }
        public string name { get { return _name; } }

        public string email { get { return _email; } }

        public UserInfo(int id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }
        static UserInfo()
        {
            var userinfo = new UserInfo(1, "aa", "bb@qq.com");
            var task = Task.Run(() =>
            {
                var a = new UserInfo(2, "bb", "bb@qq.com");
                Console.WriteLine(a.id + a.name + a.email);
            });
            task.Wait();
        }
        public static void PrintUserInfo()
        {
            var userinfo = new UserInfo(1, "aa", "aa@qq.com");

            Console.WriteLine(userinfo.id + userinfo.name + userinfo.email);
        }
    }
}
