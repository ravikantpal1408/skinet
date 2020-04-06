using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extentions
{
    public static class SwaggerExtentionService
    {
        public static IServiceCollection AddSwaggerDocumentaion(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SkiNET API",
                    Version = "V1"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "SkiNET API V1"); });
            return app;
        }
    }
}