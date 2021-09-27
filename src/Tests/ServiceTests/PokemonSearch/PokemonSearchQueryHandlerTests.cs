using Xunit;
using Moq;
using FluentAssertions;
using PokedexApi.Interface.Interfaces.Repositories;
using AutoMapper;
using PokedexApi.Service.Services.Pokemon;
using PokedexApi.Interface.Models.Pokemon;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PokedexApi.Tests.ServiceTests.PokemonSearch {
    [Trait("Pokemon", "Search")]
    public class PokemonSearchQueryHandlerTests {
        [Fact(DisplayName = "Should return any pokemon")]
        public async void ShouldReturnAnyPokemon()
        {
            var mockPokemonRepository = new Mock<IPokemonRepository>();
            var mockMapper = new Mock<IMapper>();

            var entityQuery = new PokemonEntitySearchQuery();
            var pokemon = new List<PokemonModel> {
                new PokemonModel {
                    Name = "Test"
                }
            };
            var pokemonTask = Task.FromResult<IEnumerable<PokemonModel>>(pokemon);
            mockMapper.Setup(x => x.Map<PokemonEntitySearchQuery>(It.IsAny<PokemonSearchQuery>())).Returns(entityQuery);
            mockPokemonRepository.Setup(x => x.SearchPokemonAsync(entityQuery)).Returns(pokemonTask).Verifiable();

            var handler = new PokemonSearchQueryHandler(mockPokemonRepository.Object, mockMapper.Object);
            var query = new PokemonSearchQuery();

            var result = await handler.HandleAsync(query);
            result.Should().NotBeNull();
            result.Pokemon.Should().HaveCount(1);
        }
    }
}