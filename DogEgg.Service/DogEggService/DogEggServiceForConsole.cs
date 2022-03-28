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
using Utility.LogHelper;

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
            Server =  new TcpServerDriver(9004);
            _logger.LogInformation("连接");
            Server.Connect();


        }

    }
}
