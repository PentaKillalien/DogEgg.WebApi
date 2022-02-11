using FluentScheduler;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Driver.DogEggFluentSchedulerRegistry
{
    /// <summary>
    /// 定时聊天
    /// </summary>
    public class ChatRegistry:Registry
    {
        List<string> list  = new List<string>();
        
        
        public ChatRegistry()
        {
            Schedule(() => { AutoChat(); }).ToRunNow().AndEvery(2).Seconds();
            list.Add("123");
            list.Add("1234");
            list.Add("12345");
            list.Add("123456");
            list.Add("1234567");
            list.Add("12345678");
            list.Add("123456789");
        }

        public void AutoChat() {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            if (list.Count > 0) {
                list.RemoveAt(0);
            }
        }
        
        
    }
}
