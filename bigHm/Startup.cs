using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace bigHm
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration config)
        {
            configuration = config;
        }
   
        public void ConfigureServices(IServiceCollection services)
        {
 
            services.AddAuthentication(   CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((o)=>
            {
                o.LoginPath = "/Account/LoginWindow";
            });
            services.AddMvc();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BloggingDatabase")));
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            
           
            app.UseStaticFiles();
            app.UseRouting();
app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
