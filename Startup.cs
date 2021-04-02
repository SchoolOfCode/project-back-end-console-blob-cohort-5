using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//THIS IS UP TO DATE 

namespace Server
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddTransient<>();
                        
            services.AddTransient<IRepository<CountryObj>, CountryRepository>();
            services.AddControllers();
            services.AddCors(options =>
            {

//Default Policy with Specified Server Host 
                // options.AddDefaultPolicy(
                //                   builder =>
                //                   {
                //                       // Add cross origin allowed domain
                //                       builder.WithOrigins("http://localhost:3000")
                //                                     .AllowAnyHeader()
                //                                     .AllowAnyMethod();
                //                   });

//Made Policy with Origin Specified 
                // options.AddPolicy(name: MyAllowSpecificOrigins,
                //     builder => {
                //         builder.WithOrigins("http://localhost:3000/).AllowAnyHeader().AllowAnyMethod();
                //     }  

//Default Policy 
                       options.AddDefaultPolicy(
                    builder => {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    }             
                                    );
            });
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "src", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            //     app.UseSwagger();
            //     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "src v1"));
            // }

            app.UseRouting();

//Made Policy 
            // app.UseCors(MyAllowSpecificOrigins);

//Dafault Policy 
            app.UseCors();            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



