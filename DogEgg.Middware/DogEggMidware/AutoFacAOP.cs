using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Middware.DogEggMidware
{
    public class AutoFacAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"method is {invocation.Method.Name}");
            // Console.WriteLine($"Arguments is {string.Join(';', invocation.Arguments)}");

            invocation.Proceed();// 这里表示继续执行，就去执行之前应该执行的动作了

            Console.WriteLine("**************");
        }
    }
}
