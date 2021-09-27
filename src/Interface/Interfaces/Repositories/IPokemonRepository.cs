using System.Collections.Generic;
using System.Threading.Tasks;
using PokedexApi.Interface.Models.Pokemon;

namespace PokedexApi.Interface.Interfaces.Repositories {
    public interface IPokemonRepository {
        Task<IEnumerable<PokemonModel>> SearchPokemonAsync (PokemonEntitySearchQuery query);
    }
}