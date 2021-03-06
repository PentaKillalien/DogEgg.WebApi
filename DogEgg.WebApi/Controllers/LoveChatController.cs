using DogEgg.DbAccess.DogEggDbAccess;
using DogEgg.Model.ChatModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi.Controllers
{
    public class LoveChatController : ControllerBase
    {
        ILogger<LoveChatController> _logger;
        public LoveChatController(ILogger<LoveChatController> logger)
        {
            _logger =logger;
    }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [Route("UserLogin")]
        [HttpPost]
        public string UserLogin(string Uname,string Pwd)
        {
            try
            {
                var db = new Repository<UserDto>("PostgreSQL", "PORT=5432;DATABASE=LoveChat;HOST=139.224.244.190;PASSWORD=12345678;USER ID=postgres");
                var users = db.AsQueryable().Where(it=>it.UserName==Uname&&it.Password==Pwd).ToList();
                if (users.Count == 1)
                {
                    return "success";
                }
                else {
                    return "fail";
                }
                
            }
            catch (Exception ex)
            {
                _logger?.LogInformation(ex.Message);
                return "error";
               
            }


        }

        /// <summary>
        /// 聊天机器人
        /// </summary>
        /// <returns></returns>
        [Route("ChatEcho")]
        [HttpPost]
        public string ChatEcho(string msg)
        {
            try
            {
                msg = msg + new Random().NextDouble();
                _logger.LogInformation(msg);
                return msg;

            }
            catch (Exception ex)
            {
                _logger ?.LogInformation(ex.Message);
                return "error";

            }


        }


    }
}
