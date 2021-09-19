using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MPTEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPTEditor
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
        //public Startup(IConfiguration configuration) => Configuration = configuration;
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    string connection = Configuration.GetConnectionString("ConnectionString");
        //    services.AddDbContext<FileContext>(options => options.UseSqlServer(connection));
        //    //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //    //   .AddCookie(options =>
        //    //    {
        //    //       options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Autorise");
        //    //   });
        //    services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        //    services.AddDistributedMemoryCache();

        //    services.AddSession();
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Autorise");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();

            services.AddSession();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=MainMenu}/{id?}");
            });
        }
    }
}
