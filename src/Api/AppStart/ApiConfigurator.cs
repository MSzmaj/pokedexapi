using Microsoft.Extensions.DependencyInjection;
using PokedexApi.Api.Common.Filters;

namespace PokedexApi.Api.AppStart {
    public static class ApiConfigurator {
        public static void Configure (IServiceCollection services) {
            services.AddScoped<ExceptionFilter>();
        }
    }
}