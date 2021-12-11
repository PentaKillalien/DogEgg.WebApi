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
        public ChatRegistry()
        {
            Schedule(() => { AutoChat(); }).ToRunNow().AndEvery(1).Seconds();
        }

        public void AutoChat() {
            Console.WriteLine($"定时发送，，HI,{DateTime.Now}");
        }
        
    }
}
