using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using FluentValidation.AspNetCore;
using System.Reflection;
using System.IO;
using System;

namespace PokedexApi.Api.AppStart
{
    public class Startup
    {
        private Container diContainer = new Container();

        public Startup(IConfiguration configuration)
        {
            diContainer.Options.ResolveUnregisteredConcreteTypes = false;
            diContainer.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddFluentValidation();
            services.AddSimpleInjector(diContainer, options => {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            DependencyInjector.ConfigureDependencies(services, diContainer, Configuration);
            TypeMappingConfigurator.ConfigureTypeMappings(services);
            ApiConfigurator.Configure(services);

            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(diContainer);
            
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            diContainer.Verify();
        }
    }
}
