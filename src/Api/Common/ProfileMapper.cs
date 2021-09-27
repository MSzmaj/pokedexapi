using AutoMapper;

namespace PokedexApi.Api.Common {
    public class ProfileMapper : Profile {
        public ProfileMapper () : base (nameof(ProfileMapper)) {
            CreateMap<PokedexApi.DataAccess.EntityModels.Pokemon.PokemonEntity, PokedexApi.Interface.Models.Pokemon.PokemonModel>();
            CreateMap<PokedexApi.Service.Services.Pokemon.PokemonSearchQuery, PokedexApi.Interface.Models.Pokemon.PokemonEntitySearchQuery>();
            CreateMap<PokedexApi.Api.InputModels.PokemonSearchCriteria, PokedexApi.Service.Services.Pokemon.PokemonSearchQuery>();
        }
    }
}