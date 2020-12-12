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
using MCZ_Maestro_API.Interfaces;
using MCZ_Maestro_API.Services;

namespace MCZ_Maestro_API
{
    public class Startup
    {

        private readonly OpenApiInfo openApiInfo = new OpenApiInfo
        {
            Title = "Maestro-API",
            Version = "v1",
            Description = "Maestro Oven API",

            Contact = new OpenApiContact
            {
                Name = "Dev-Gogi",
                Email = string.Empty,
                Url = new Uri("https://twitter.com/devgogi"),
            }
        };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddMvc();
            services.AddSingleton<IMaestroService, MaestroService>();

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc(openApiInfo.Version, openApiInfo);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", openApiInfo.Title);
            });

        }
    }
}
