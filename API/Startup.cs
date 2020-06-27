using System.Linq;
using API.Errors;
using API.Extensions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfiles)); // injecting auto mapper service 👈

            services.AddControllers();

            services.AddApplicationService(); // Collection of all custom services 😎

            services.AddSwaggerDocumentation(); // Custom Extension reference 😎 

            services.AddDbContext<StoreContext>(x => x.UseSqlite(
                _configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(x =>
                {
                    x.UseSqlite(_configuration.GetConnectionString("IdentityConnection"));
                });
            
            
            // for redis db 🤠
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            
            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // instead of 👆 we will use 👇 our custom middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}"); // This is custom error handler middleware 🤪

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles(); // Serving static content 🧑‍🚀👍
            
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseSwaggerDocumentation(); // swagger custom reference from extension 🤓

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}