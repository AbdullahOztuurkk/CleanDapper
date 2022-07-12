using DapperORM.Application;
using DapperORM.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using System;

namespace DapperORM.WebApi
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

            services.AddControllers();
            services.AddSwaggerDocument(config =>
                config.PostProcess = ( settings => {
                    settings.Info.Title = "DapperORM.WebApi";
                    settings.Info.Description = "Dapper Tutorial with Clean Architecture";
                    settings.Info.Contact = new OpenApiContact
                    {
                        Email = "oabdullahozturk@yandex.com",
                        Name = "Abdullah Öztürk",
                        Url = "https://abdullahozturk.live",
                    };
                    settings.Info.Version = "v1";
                }
            ));
            services.AddPersistenceDependencies();
            services.AddApplicationDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
