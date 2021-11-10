using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Model.ChatModel
{
    [SugarTable("UserDto")]
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
        public int id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
