using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyException
{
    public static class ThrowAndThrowEx
    {
        public static void ThrowEx()
        {
            throw new Exception("test throw ex");
        }

        public static void Demo1()
        {
            try
            {
                ThrowEx();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //如果是需要抛出的类型，需要直接throw 不然会丢失堆栈信息
        public static void Demo2()
        {
            try
            {
                ThrowEx();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
