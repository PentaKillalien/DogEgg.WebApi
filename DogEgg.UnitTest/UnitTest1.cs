using DogEgg.DbAccess.DogEggDbAccess;
using DogEgg.Model.ChatModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace DogEgg.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LeetCode()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.PostgreSQL,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                ConnectionString = "PORT=5432;DATABASE=LoveChat;HOST=139.224.244.190;PASSWORD=12345678;USER ID=postgres",
                MoreSettings = new ConnMoreSettings()
                {
                    PgSqlIsAutoToLower = false //���ݿ���ڴ�д�ֶε� ����Ҫ�������Ϊfalse
                }
            });
            db.CodeFirst.SplitTables().InitTables<UserDto>();
            db.Insertable(new UserDto()
            {
                Email = "21312@qq.com",
                CreateTime = DateTime.Now,
                UserName = "JSAOd",
                Password = "ssss"
            }).SplitTable().ExecuteReturnSnowflakeId();//���벢����ѩ��ID
        }
    }
}
