using Microsoft.Extensions.DependencyInjection;
using PokedexApi.Api.Common;

namespace PokedexApi.Api.AppStart
{
    public static class TypeMappingConfigurator
    {
        public static void ConfigureTypeMappings(IServiceCollection services)
        {
            ConfigureDomainToApplicationTypeMappings(services);
        }

        private static void ConfigureDomainToApplicationTypeMappings (IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileMapper));
        }
    }
}
