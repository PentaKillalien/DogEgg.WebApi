using DogEgg.Core.DogEggInterface;
using DogEgg.DbAccess.DogEggDbAccess;
using DogEgg.Driver.DogEggDriver;
using DogEgg.Model.ChatModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Service.DogEggService
{
    public class DogEggServiceForConsole : DogEggServiceInterface
    {
        ILogger<DogEggServiceForConsole> _logger;
        public DogEggServiceForConsole(ILogger<DogEggServiceForConsole> logger)
        {
            _logger = logger;
        }
        private TcpServerDriver Server =null;
        public void Start()
        {
            _logger.LogInformation("启动");
            _logger.LogDebug("启动");
            _logger.LogError("启动");
            Server =  new TcpServerDriver(9004);
            Server.Connect();
            Server.InfoTrigger = new Action<string,string>(InfoTrigger);


        }

        private void InfoTrigger(string Info,string ip) {
            Server.SendInfoBack(Info, ip);
        }
    }
}
