using Microsoft.Extensions.Hosting;
using SuperSocket;
using SuperSocket.Channel;
using SuperSocket.ProtoBase;
using SuperSocket.Server;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Driver.DogEggDriver
{
    public class TcpServerDriver
    {
        private static List<IAppSession> Sessions { get; set; } = new List<IAppSession>();
        private int Port = 0;//端口
        public TcpServerDriver(int port)
        {
            Port = port;

        }

        public void SendInfoBack(string info,string ip) {
            if (Sessions != null) {
                foreach (var item in Sessions)
                {
                    if (item.RemoteEndPoint.ToString().Contains(ip)) {
                        item.SendAsync(Encoding.ASCII.GetBytes(info));
                    }
                }
            }
        }
        public Action<string,string> InfoTrigger;
        public void Connect() {
            Task.Factory.StartNew(async () => {
                var host = SuperSocketHostBuilder.Create<TextPackageInfo, MyLinePipelineFilter>().UsePackageHandler(async (s, p) =>
                {
                    try
                    {
                        try
                        {
                            InfoTrigger?.Invoke(p.Text.ToString(),s.RemoteEndPoint.ToString().Split(':')[0]);

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    await new ValueTask();
                }).UseSession<MyAppSession>().ConfigureSuperSocket(options =>//配置服务器如服务器名和监听端口等基本信息
                {
                    options.Name = "Chat";
                    options.ReceiveBufferSize = 2048;
                    options.Listeners = new List<ListenOptions>(){
                        new ListenOptions{
                         Ip="Any",
                         Port = Port
                        }
                          };
                }).Build();

                await host.RunAsync();
            });
        }
        public class MyLinePipelineFilter : TerminatorPipelineFilter<TextPackageInfo>
        {
            protected Encoding Encoding { get; private set; }

            public MyLinePipelineFilter()
                : this(Encoding.ASCII)
            {

            }

            public MyLinePipelineFilter(Encoding encoding)
                : base(new[] { (byte)'\r', (byte)'\n' })
            {
                Encoding = encoding;
            }

            protected override TextPackageInfo DecodePackage(ref ReadOnlySequence<byte> buffer)
            {
                return new TextPackageInfo { Text = buffer.GetString(Encoding) };
            }
        }
        /// <summary>
        /// 自定义的AppSession
        /// </summary>
        public class MyAppSession : AppSession
        {
            protected override ValueTask OnSessionConnectedAsync()
            {
                Sessions.Add(this);
                return base.OnSessionConnectedAsync();
            }

            protected override async ValueTask OnSessionClosedAsync(CloseEventArgs e)
            {
                Sessions.Remove(this);
                await base.OnSessionClosedAsync(e);
            }
        }
    }
}
