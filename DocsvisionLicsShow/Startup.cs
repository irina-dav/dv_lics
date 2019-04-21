using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DocsvisionLicsShow.Data;
using Microsoft.EntityFrameworkCore;
using DocsvisionLicsShow.Models;

namespace DocsvisionLicsShow
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DvSettings>(Configuration.GetSection("DvSettings"));

            services.AddDbContext<DvDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DvBase")));

            services.AddTransient<IDvRepository, DVRepository>();

            services.AddMvc();

        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }           
            app.UsePathBase(Configuration["PathBase"]);
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Sessions}/{action=List}");
            });
        }
    }
}
