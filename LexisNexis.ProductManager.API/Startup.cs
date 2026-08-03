using LexisNexis.ProductManager.Contracts.Services;
using LexisNexis.ProductManager.Core;
using LexisNexis.ProductManager.Infrastructure;
using LexisNexis.ProductManager.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ProductManager
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
            services.AddScoped<ISearchCacheService, SearchCacheService>();
            services.AddScoped<IProductSearchEngine, ProductSearchEngine>();

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    policy =>
                    {
                        policy.WithOrigins(
                            "https://localhost:59552", 
                            "http://localhost:59552", 
                            "http://localhost:4200") // Angular dev server
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin();
                    });
            });

            services.AddPersistence(Configuration);
            services.AddCore();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LexisNexis Product Manager API", Description = "Product Manager is a light  solution, built to demonstrate implementing Command Query Responsibility Segregation - CQRS in ASP.NET Core (.NET 6) via MediatR.", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAngularDev");
            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Manager API v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseCors("AllowAngularDev");

        }
    }
}
