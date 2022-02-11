using Microsoft.Data.Sqlite;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Model.ChatModel
{
    [SplitTable(SplitType.Day)]
    [SugarTable("UserDto_{year}{month}{day}")]
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]//主键并且自增 （string不能设置自增）
        public long Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        [SplitField] //分表字段 在插入的时候会根据这个字段插入哪个表，在更新删除的时候用这个字段找出相关表
        public DateTime CreateTime { get; set; }
    }

}
