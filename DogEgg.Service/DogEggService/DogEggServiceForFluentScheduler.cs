using DogEgg.Core.DogEggInterface;
using DogEgg.Driver.DogEggDriver;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Service.DogEggService
{
    public class DogEggServiceForFluentScheduler : DogEggServiceInterface
    {
        
        public DogEggServiceForFluentScheduler()
        {
        }
        public void Start()
        {
            var job = new FluentSchedulerDriver();
            job.Connect();

        }
    }
}
