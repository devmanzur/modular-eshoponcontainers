using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Catalog.Api.Utils
{
    public static class SaggerDependencyUtils
    {
        public static void AddSwagger(this IServiceCollection services, string title, string description)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = title,
                    Description = description,
                    Contact = new OpenApiContact
                    {
                        Name = "Manzur Alahi",
                        Email = "devmanzur@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/devmanzur")
                    },
                    Version = "v1"
                });
                c.ExampleFilters();
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}