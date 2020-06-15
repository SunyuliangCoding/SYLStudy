using System;
using System.Threading.Tasks;

namespace ThreadStudy
{
    class Program
    {
        //多线程修改类的不同字段 ，目前看来是线程安全的
        static void Main(string[] args)
        {
            var user = new User() { UserName = "zhangsan" };
            for (int i = 0; i < 100; i++)
            {
                var task1 = Task.Factory.StartNew(u =>
                {
                    var item = u as User;
                    item.Age++;
                }, user);

                var task2 = Task.Factory.StartNew(u =>
                {
                    var item = u as User;
                    item.Gender = !item.Gender;
                }, user);

                var task3 = Task.Factory.StartNew(u =>
                {
                    var item = u as User;
                    item.UserName = item.UserName + "a";
                }, user);
                Task.WaitAll(new Task[] { task1, task2, task3 });
            }
            Console.WriteLine($"name:{user.UserName}, age={user.Age},gender={user.Gender}");
            Console.ReadKey();
        }
    }
    public class User
    {
        public int Age { get; set; }
        public string UserName { get; set; }
        public bool Gender { get; set; }
    }
}
