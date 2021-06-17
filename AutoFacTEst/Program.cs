using Autofac;
using AutoFaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            //AutoFaceService.dll
            var ass = Assembly.LoadFile(System.Environment.CurrentDirectory+"/AutoFaceService.dll");

            var builder1 = new ContainerBuilder();
            builder1.RegisterAssemblyTypes(ass)
    .Where(t => t.Name.EndsWith("Service"))
    .AsSelf().AsImplementedInterfaces().SingleInstance()
    .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder1.Register(n => new AService())
              .As<AService>().SingleInstance();


            builder1.Build();

            builder1.Register(n => new AService())
         .As<AService>().SingleInstance();
            builder1.RegisterAssemblyTypes(ass)
 .Where(t => t.Name.EndsWith("Service"))
 .AsSelf().AsImplementedInterfaces().SingleInstance()
 .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder1.Build();
        }
    }

}
