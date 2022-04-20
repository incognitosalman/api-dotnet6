using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Development",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Email = "salman1277@gmail.com",
                        Name = "Salman Malik",
                        Url = new Uri("https://github.com/salman-develop?tab=repositories")
                    },
                    Description = "API development using .NET 6 and Entity Framework Core",
                    License = new OpenApiLicense
                    {
                        Name = "GNU Open Source",
                        Url = new Uri("https://github.com/salman-develop?tab=repositories")
                    },
                    TermsOfService = new Uri("https://github.com/salman-develop?tab=repositories")
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Learning API development using .NET 6";
                options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
