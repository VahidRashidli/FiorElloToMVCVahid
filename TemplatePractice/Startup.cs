using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TemplatePractice.Areas.Admin.Constants;
using TemplatePractice.Areas.Admin.Utilities.File;
using TemplatePractice.DAL;
using TemplatePractice.Models;

namespace TemplatePractice
{
  
    public class Startup
    {
        private IConfiguration _config;
        private IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }
            );
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(_config.GetConnectionString("Default"));
            });
            services.AddIdentity<User, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            FileNameConstants.Image = Path.Combine(_env.WebRootPath, "img");
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Dashboard}/{id?}"
                );
            });

            app.UseEndpoints(configure =>
            {
                configure.MapControllerRoute("default", "{controller=Home}/{action=Index}/{count?}");
            });
        }
    }
}
