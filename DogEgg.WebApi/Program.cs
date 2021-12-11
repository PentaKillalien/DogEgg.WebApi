using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //������־
            .ConfigureLogging((hostBuilder,logging) => { 
                logging.ClearProviders ();//���ϵͳĬ����־
                logging.AddLog4Net("log4net.config");
            
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())//����AutoFac
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:5000").
                    UseStartup<Startup>();

                });
    }
}
