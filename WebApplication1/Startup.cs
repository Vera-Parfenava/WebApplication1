using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebApplication1.Interfaces;
using WebApplication1.Infrastructure.Interfaces;
using WebApplication1.Infrastructure.InMemory;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Context;
using WebApplication1.Data;
using WebApplication1.Infrastructure.InSQL;
using WebApplication1.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

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
            services.AddDbContext<WebStoreDB>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<WebStoreDB>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequiredUniqueChars = 3;
#endif
                opt.User.RequireUniqueEmail = false;
                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(15);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "GB.WebStore";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = System.TimeSpan.FromDays(10);
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true;
            });

            services.AddTransient<WebApp1DBInitializer>();

            services.AddSingleton<IGuestsData, InMemoryGuestsData>();
            //services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();

            //Add  a service for controller
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //Add a dependency extension
            services.AddSingleton<IGuestsData, InMemoryGuestsData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

           app.UseStatusCodePagesWithReExecute("/Home/status/{0}");

            //Add an extension for static files, since appsettings.json is a static file

            app.UseStaticFiles(); 
            app.UseRouting();

            app.UseWelcomePage("/welcome");

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
