using DogEgg.Core.DogEggInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Service.DogEggService
{
    public class DogEggServiceForConsole : DogEggServiceInterface
    {
        public void Start()
        {
            Console.WriteLine("启动");
        }
    }
}
