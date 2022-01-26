using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TaskTracker.Data;
using TaskTracker.Services;

namespace TaskTracker
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskTrackerContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("TaskTrackerConnectionString"));
            });
            services.AddCors(o => o.AddPolicy("ShedDevPolicy", builder =>
           {
               builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();

           }));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("ShedDevPolicy"));
            });
            services.AddScoped<ITaskTracker, TaskTrackerRepository>();
            services.AddTransient<TaskTrackerSeeder>();
            services.AddAutoMapper();

            services.AddMvc()
                 .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                 .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseFileServer();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ShedDevPolicy");

            app.UseMvc(cfg => {
                cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "TaskTrackerAPI"  });
            });

            if (env.IsDevelopment())
            {
                //Seed the db
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<TaskTrackerSeeder>();
                    seeder.Seed();
                }
            }

            var config = new TaskTrackerMappingProfile();
            config.InitMapping();
        }
    }
}
