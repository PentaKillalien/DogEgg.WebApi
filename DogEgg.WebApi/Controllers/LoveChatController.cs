using DogEgg.DbAccess.DogEggDbAccess;
using DogEgg.Model.ChatModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi.Controllers
{
    public class LoveChatController : ControllerBase
    {
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
                var db = new Repository<UserDto>("PostgreSQL", "PORT=5432;DATABASE=test_db;HOST=122.112.204.106;PASSWORD=123456;USER ID=pzl");
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
                Console.WriteLine(ex.Message);
                return "error";
               
            }


        }

       
    }
}
