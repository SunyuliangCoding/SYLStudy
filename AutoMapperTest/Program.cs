using AutoMapper;
using AutoMapperTest.NameSpaceA;
using AutoMapperTest.NameSpaceB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SchoolA, SchoolB>();
                cfg.CreateMap<StudentA, StudentB>();
            });
            var mapper = config.CreateMapper();

            SchoolA schoolA = new SchoolA
            {
                Name = "abc",
                PersionCount = 10,
                SingleStudent = new StudentA
                {
                    Aget = 1,
                    Name = "zhangsan"
                },
                studentList = new List<StudentA> {
                    new StudentA {
                        Aget = 2,
                        Name = "lisi"
                    }
                },
                studentDic = new Dictionary<string, StudentA> {
                    { "a",new StudentA{  Aget=3, Name="wangwu"} }
                }
            };

            var schoolB = new SchoolB();
            mapper.Map(schoolA, schoolB);
            var b = mapper.Map<object>(schoolA);


        }


        static void TestMapper<T>(T t) where T : class
        {

        }

    }
}
