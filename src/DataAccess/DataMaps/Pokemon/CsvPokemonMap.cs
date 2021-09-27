using System.Globalization;
using CsvHelper.Configuration;
using PokedexApi.DataAccess.EntityModels.Pokemon;

namespace PokedexApi.DataAccess.DataMaps {
    public class CsvPokemonMap : ClassMap<PokemonEntity> {
        public CsvPokemonMap () {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.Id).Ignore();
        }
    }
}