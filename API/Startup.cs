using System.Linq;
using API.Errors;
using API.Extentions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddSwaggerDocumentaion(); // Custom Extension reference 😎 

            services.AddDbContext<StoreContext>(x => x.UseSqlite(
                _configuration.GetConnectionString("DefaultConnection")));


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

            app.UseStaticFiles(); // Serving static content 🧑‍🚀

            app.UseAuthorization();

            app.UseSwaggerDocumentation(); // swagger custom reference from extension 🤓

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}