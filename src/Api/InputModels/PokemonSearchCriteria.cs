using System.Collections.Generic;

namespace PokedexApi.Api.InputModels {
    public class PokemonSearchCriteria : PagingParameters {
		public Dictionary<string, int> Number { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public Dictionary<string, int> Total { get; set; }
        public Dictionary<string, int> Hp { get; set; }
        public Dictionary<string, int> Attack { get; set; }
        public Dictionary<string, int> Defense { get; set; }
        public Dictionary<string, int> SpAttack { get; set; }
        public Dictionary<string, int> SpDefense { get; set; }
        public Dictionary<string, int> Speed { get; set; }
        public Dictionary<string, int> Generation { get; set; }
        public bool Legendary { get; set; }
    }
}