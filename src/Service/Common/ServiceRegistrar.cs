using Microsoft.Extensions.DependencyInjection;
using PokedexApi.Service.Services.Pokemon;
using PokedexApi.Common.Query;
using FluentValidation.AspNetCore;
using PokedexApi.Service.Services.Pokemon.Validation;
using FluentValidation;
using PokedexApi.Service.Validation;
using SimpleInjector;
using System.Reflection;

namespace PokedexApi.Service.Common {
    public static class ServiceRegistrar {
        public static void RegisterDependencies (
                IServiceCollection services, 
                Container container,
                Assembly[] assemblies) {
            services.AddMvc().AddFluentValidation();

            RegisterHandlers(container, assemblies);
            RegisterValidators(container);
            RegisterDecorators(container);
        }

        private static void RegisterHandlers (Container container, Assembly[] assemblies) {
            container.Register(typeof(IQueryHandler<,>), assemblies);
        }

        private static void RegisterValidators (Container container) {
            container.Register<IValidator<PokemonSearchQuery>, PokemonSearchQueryValidator>(Lifestyle.Transient);
        }

        private static void RegisterDecorators (Container container) {
            //container.RegisterDecorator<IQueryHandler<PokemonSearchQuery, PokemonSearchResult>, ValidationQueryHandler<PokemonSearchResult, PokemonSearchResult>();
            container.RegisterDecorator(typeof(IQueryHandler<PokemonSearchQuery,PokemonSearchResult>), typeof(ValidationQueryHandler<PokemonSearchQuery,PokemonSearchResult>));
        }
    }
}