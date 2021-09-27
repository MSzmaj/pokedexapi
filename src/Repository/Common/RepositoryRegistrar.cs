using PokedexApi.Repostory.Repositories;
using PokedexApi.Interface.Interfaces.Repositories;
using SimpleInjector;

namespace PokedexApi.Repository.Common {
    public static class RepositoryRegistrar {
        public static void RegisterDependencies (Container container) {
            container.Register<IPokemonRepository, PokemonRepository>(Lifestyle.Transient);
        }
    }
}