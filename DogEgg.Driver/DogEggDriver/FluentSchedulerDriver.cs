using DogEgg.Driver.DogEggFluentSchedulerRegistry;
using FluentScheduler;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Driver.DogEggDriver
{
    public class FluentSchedulerDriver
    {
        public FluentSchedulerDriver()
        {

        }
        /// <summary>
        /// 连接驱动
        /// </summary>
        public void Connect() {
            JobManager.Initialize(new ChatRegistry());
        }

    }
}
