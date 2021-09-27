using System.Threading.Tasks;
using PokedexApi.Common.Query;
using PokedexApi.Interface.Interfaces.Repositories;
using AutoMapper;
using PokedexApi.Interface.Models.Pokemon;

namespace PokedexApi.Service.Services.Pokemon {
	public class PokemonSearchQueryHandler : IQueryHandler<PokemonSearchQuery, PokemonSearchResult> {
		private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonSearchQueryHandler (IPokemonRepository pokemonRepository, IMapper mapper) {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<PokemonSearchResult> HandleAsync (PokemonSearchQuery query) {
            var result = await _pokemonRepository.SearchPokemonAsync(_mapper.Map<PokemonEntitySearchQuery>(query));
            
            return new PokemonSearchResult {
                Pokemon = result
            };
        }
	}
}
