using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Middware.DogEggMidware
{
    public class AutoFacMiddware : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            var ServicesDllFile = Path.Combine(basePath, "DogEgg.Service.dll");

            if (! File.Exists(ServicesDllFile) )
            {
                var msg = "dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                throw new Exception(msg);
            }

            // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
            var cacheType = new List<Type>();

            //autofac 允许使用Aop
            builder.RegisterType<AutoFacAOP>();
            cacheType.Add(typeof(AutoFacAOP));

            // 获取 Services.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(ServicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()  //属性自动注入
                      .SingleInstance();//返回单例对象
                                       // .InstancePerDependency() //每次请求 Resovle都返回一个新对象。InstancePerDependency()【这也是默认的创建实例的方式。】
                      //.EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;
                                                     //.InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

        }
    }
}
