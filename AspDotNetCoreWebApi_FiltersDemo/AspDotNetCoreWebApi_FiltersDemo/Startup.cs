using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebApi_FiltersDemo.Filters;
using AspDotNetCoreWebApi_FiltersDemo.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspDotNetCoreWebApi_FiltersDemo
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


            services.AddMvc(config =>
            {                
                //Registering the exception filter at global level;
                //config.Filters.Add(typeof(ExceptionFilterEampleWithAttribute));

                config.Filters.Add(typeof(ServiceTypeActionFilter),2); //ServiceFilter(typeof(ServiceTypeActionFilter), Order = 2)

                //config.filters.add(new actionfilterexample());
                //config.Filters.Add(typeof(ActionFilterExample));
            });

            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));
            });

            services.AddScoped<ServiceTypeActionFilter>();

            services.AddScoped<ClassConsoleLogActionOneFilter>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//, ILoggerManager logger
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Handling the excepion using ExceptionHandler
             app.ConfigureExceptionHandler(); 

            //Handling the excepion using Custom exception Middleware
             //app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
                
        }
    }
}
