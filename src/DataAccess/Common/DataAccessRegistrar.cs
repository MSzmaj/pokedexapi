using PokedexApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using PokedexApi.DataAccess.Context;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using PokedexApi.Common.Common;

namespace PokedexApi.DataAccess.Common {
    public static class DataAccessRegistrar {
        public static void RegisterDependencies (Container container, IConfiguration configuration) {
            container.Register<DbContext>(() => {
                var optionsBuilder = new DbContextOptionsBuilder<PokemonDbContext>();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString(Constants.DbContext)).UseLowerCaseNamingConvention();
                return new PokemonDbContext(optionsBuilder.Options);
            }, Lifestyle.Scoped);

            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>), Lifestyle.Scoped);
        }
    }
}