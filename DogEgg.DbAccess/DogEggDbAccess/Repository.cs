using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.DbAccess.DogEggDbAccess
{
    public class Repository<T> : SimpleClient<T> where T : class, new()
    {
        public Repository(string DbType, string Connstr, ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            if (context == null)
            {


                string dbType = DbType;
                base.Context = dbType switch
                {
                    "Oracle" => new SqlSugarClient(new ConnectionConfig()
                    {
                        DbType = SqlSugar.DbType.Oracle,
                        InitKeyType = InitKeyType.Attribute,
                        IsAutoCloseConnection = true,
                        ConnectionString = Connstr//连接符字串
                    }),
                    "SqlServer" => new SqlSugarClient(new ConnectionConfig()
                    {
                        DbType = SqlSugar.DbType.SqlServer,
                        InitKeyType = InitKeyType.Attribute,
                        IsAutoCloseConnection = true,
                        ConnectionString = Connstr//连接符字串
                    }),
                    "Sqlite" => new SqlSugarClient(new ConnectionConfig()
                    {
                        DbType = SqlSugar.DbType.Sqlite,
                        InitKeyType = InitKeyType.Attribute,
                        IsAutoCloseConnection = true,
                        ConnectionString = Connstr//连接符字串
                    }),
                    "PostgreSQL" => new SqlSugarClient(new ConnectionConfig()
                    {
                        DbType = SqlSugar.DbType.PostgreSQL,
                        InitKeyType = InitKeyType.Attribute,
                        IsAutoCloseConnection = true,
                        ConnectionString = Connstr,
                        MoreSettings = new ConnMoreSettings()
                        {
                            PgSqlIsAutoToLower = false //数据库存在大写字段的 ，需要把这个设为false
                        }
                    }),
                    _ => null,
                };
            }
        }
    }

}
