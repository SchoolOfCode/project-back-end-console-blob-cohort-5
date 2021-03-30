using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Server
{
    public class Startup
    {
         readonly string frontEnd = "_frontEnd";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddTransient<IRepository<CountryObj>, CountryRepository>();
            services.AddControllers();
            services.AddCors(options =>
      {
          options.AddPolicy(name: frontEnd,
                            builder =>
                            {
                                builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowCredentials() //adding this line corrected the CORS error we were getting
                                .AllowAnyMethod();
                            });
        services.AddTransient<IRepository<CountryObj>, CountryRepository>();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            // });
        });
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (env.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        //     app.UseSwagger();
        //     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
        // }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(frontEnd);
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
