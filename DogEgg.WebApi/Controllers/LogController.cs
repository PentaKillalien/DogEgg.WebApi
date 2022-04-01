using DogEgg.Model.NetSwap;
using DogEgg.Model.NetSwap.Log;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi.Controllers
{
    public class LogController : ControllerBase
    {
        /// <summary>
        /// 获取模拟日志
        /// </summary>
        /// <returns></returns>
        [Route("/api/log/faker/loginfos")]
        [HttpPost]
        public StandardDataDto AuthPermission()
        {
            try
            {
                return new StandardDataDto() { 
                    Stauts=0,
                     Data = new List<LogDto>() { 
                      new LogDto(){ 
                       ID=1,
                        LogDate=DateTime.Now.ToString(),
                         LogInfo=new Random().NextDouble().ToString(),
                          LogLevel="INFO"
                      },new LogDto(){
                       ID=2,
                        LogDate=DateTime.Now.ToString(),
                         LogInfo=new Random().NextDouble().ToString(),
                          LogLevel="DEBUG"
                      },new LogDto(){
                       ID=3,
                        LogDate=DateTime.Now.ToString(),
                         LogInfo=new Random().NextDouble().ToString(),
                          LogLevel="REEOR"
                      },
                     },
                      Message="abc",
                       Success=true
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return null;

            }


        }
    }
    
}
