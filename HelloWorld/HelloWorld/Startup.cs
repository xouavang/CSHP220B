using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HelloWorld
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                    {
                        options.LoginPath = new PathString("/Account/LogOn");
                        options.AccessDeniedPath = new PathString("/Account/Denied");
                    });

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.Configure<MyJsonSettings>(Configuration);

            services
            // Add FULL MVC handling (Do not call AddMvcCore(), this will only add the minimum to get MVC to work, which is not what we want)
            .AddMvc(options =>
                {
                    options.CacheProfiles.Add("Default", new CacheProfile { Duration = 60 });
                    options.CacheProfiles.Add("Login", new CacheProfile { Duration = 60 }); // A catch profile for each page if needed.
                    options.CacheProfiles.Add("ShoppingCart", new CacheProfile { Duration = 60 });
                })
            // Be explicit in what version MVC should be using
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // Add this to allow ASP.NET to download additional file (Style.css). By default ASP.NET does not download additional file.
            app.UseSession(); // before app.UseMvc

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
