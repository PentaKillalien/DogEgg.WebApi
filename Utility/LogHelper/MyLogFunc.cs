using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utility.LogHelper
{
    public static class MyLogFunc
    {
        /// <summary>
        /// 自定义OPLog目录下是文件生成日志
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteOpLogPlus( string msg, string fileName)
        {
            try
            {
                string patch = $"{AppDomain.CurrentDomain.BaseDirectory}\\OpLog\\{DateTime.Today.ToString("yyyy-MM-dd")}";
                if (!Directory.Exists(patch))
                {
                    Directory.CreateDirectory(patch);
                }
                string LogsPath = @$"{AppDomain.CurrentDomain.BaseDirectory}OpLog\{DateTime.Today.ToString("yyyy-MM-dd")}\{fileName}.txt";
                if (!File.Exists(LogsPath)) {
                    var myFile =File.Create(LogsPath);
                    myFile.Close();
                     
                }
                //写入数据
                FileStream fs = new FileStream(LogsPath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine($"{DateTime.Now.ToString()},{msg}\n");

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                //Log4NetHelper.WriteErrorLog("操作日志记录错误", ex);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
