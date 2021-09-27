using System;

namespace PokedexApi.Common.Exceptions {
    public class PokemonNotFoundException : Exception {
        public PokemonNotFoundException (string id) : base ($"{id}: Not Found") {}
    }
}