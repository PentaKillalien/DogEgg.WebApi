using Autofac;
using DogEgg.Core.DogEggInterface;
using DogEgg.Middware.DogEggMidware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogEgg.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂 集成Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //添加依赖注入实例，AutofacModuleRegister就继承自Autofac.Module的类
            builder.RegisterModule(new AutoFacMiddware());

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddCors(o => o.AddPolicy("any", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));    //services.AddCors(o=>o.AddPolicy("any",p=>p.WithOrigins(["https://www.baidu.com","https://www.baidu.com"])().AllowAnyHeader().AllowAnyMethod()));
                                                                                                                     //AllowAnyOrigin()允许所有域名跨域、WithOrigins()允许指定域名跨域

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DogEgg.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IEnumerable<DogEggServiceInterface> serviceList)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DogEgg.WebApi v1"));
            }
            app.UseMiddleware<CorsMidWare>();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ServiceFilterImpl(serviceList);
        }
    }
}
