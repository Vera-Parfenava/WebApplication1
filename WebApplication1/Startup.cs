using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        ///<summary>
        ///Add a property to access the configuration
        ///</summary>
        public IConfiguration Configuration { get; }

        ///<summary>
        ///Add new constructor used interface IConfiguration
        ///</summary> 
        /// <param name="configuration"></param>
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add  a service for controller
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Add an extension for static files, since appsettings.json is a static file
            app.UseStaticFiles(); 
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Make the configuration of the infrastructure MVC
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}