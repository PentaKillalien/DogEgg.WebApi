using DogEgg.Core.DogEggInterface;
using DogEgg.DbAccess.DogEggDbAccess;
using DogEgg.Driver.DogEggDriver;
using DogEgg.Model.ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Service.DogEggService
{
    public class DogEggServiceForConsole : DogEggServiceInterface
    {
        private TcpServerDriver Server =null;
        public void Start()
        {

            Server =  new TcpServerDriver(9004);
            Server.Connect();
            Server.InfoTrigger = new Action<string,string>(InfoTrigger);


        }

        private void InfoTrigger(string Info,string ip) {
            Server.SendInfoBack(Info, ip);
        }
    }
}
