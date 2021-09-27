using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using PokedexApi.Api.Common;
using PokedexApi.Common.Common;
using PokedexApi.DataAccess.Common;
using PokedexApi.Repository.Common;
using PokedexApi.Service.Common;

namespace PokedexApi.Api.AppStart
{
    public static class DependencyInjector
    {
        public static void ConfigureDependencies (
                IServiceCollection services, 
                Container container, 
                IConfiguration configuration)
        {   
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                                .Where(x => x.GetName().Name.StartsWith("PokedexApi"))
                                .ToArray();

            ApiRegistrar.RegisterDependencies(container);
            CommonRegistrar.RegisterDependencies(container);
            DataAccessRegistrar.RegisterDependencies(container, configuration);
            RepositoryRegistrar.RegisterDependencies(container);
            ServiceRegistrar.RegisterDependencies(services, container, assemblies);
        }
    }
}