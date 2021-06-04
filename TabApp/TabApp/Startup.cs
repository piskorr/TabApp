using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace TabApp
{
    public class Startup
    {
       public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if(Environment.IsDevelopment())
            {
                services.AddDbContext<PagePersonContext>(options =>
                        options.UseSqlite(Configuration.GetConnectionString("PagePersonContext")));
            }
            else
            { services.AddDbContext<PagePersonContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PagePersonContext")));

            }
            
            services.AddRazorPages();

            //services.AddDbContext<RegisterPersonContext>(options =>
                 //  options.UseSqlite(Configuration.GetConnectionString("RegisterPersonContext")));

           // services.AddDbContext<RazorPagesWorkerContext>(options =>
                  //  options.UseSqlite(Configuration.GetConnectionString("RazorPagesWorkerContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
