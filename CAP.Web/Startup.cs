using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAP.Web.Codes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CAP.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CAPDbContext>(options => options.UseSqlServer(ConnectionString));
            services.AddCap(x =>
            {
                x.UseEntityFramework<CAPDbContext>();
                var capConfig = Configuration.GetSection("CAP_RabbitMQ");
                x.UseRabbitMQ(rb =>
                {
                    //rabbitmq服务器地址
                    rb.HostName = capConfig["HostName"];
                    rb.UserName = capConfig["UserName"];
                    rb.Password = capConfig["Password"];
                    ////指定Topic exchange名称，不指定的话会用默认的
                    rb.ExchangeName = capConfig["ExchangeName"];

                });

                x.UseDashboard();

                x.SucceedMessageExpiredAfter = capConfig.GetValue<int>("SucceedMessageExpiredAfter");
                x.FailedRetryCount = capConfig.GetValue<int>("FailedRetryCount");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
