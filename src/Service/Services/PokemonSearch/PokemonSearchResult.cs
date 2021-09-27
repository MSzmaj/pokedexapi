using System.Collections.Generic;
using PokedexApi.Interface.Models.Pokemon;

namespace PokedexApi.Service.Services.Pokemon {
	public class PokemonSearchResult {
		public IEnumerable<PokemonModel> Pokemon { get; set; }
	}
}
