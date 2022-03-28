using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi.Controllers
{
    public class AuthValidController : ControllerBase
    {
        /// <summary>
        /// 权限验证
        /// </summary>
        /// <returns></returns>
        [Route("/api/auth/permission/routes")]
        [HttpPost]
        public string AuthPermission(Object obj)
        {
            try
            {
                Console.WriteLine();
                return "";

            }
            catch (Exception ex)
            {
                return $"error:{ex.Message}";

            }


        }
    }
}
