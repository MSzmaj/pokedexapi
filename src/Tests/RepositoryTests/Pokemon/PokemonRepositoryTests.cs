using Xunit;
using Moq;
using FluentAssertions;
using AutoMapper;
using PokedexApi.Interface.Models.Pokemon;
using System.Collections.Generic;
using PokedexApi.DataAccess.Interfaces;
using PokedexApi.DataAccess.EntityModels.Pokemon;
using PokedexApi.Repostory.Repositories;
using System.Linq;
using MockQueryable.Moq;

namespace PokedexApi.Tests.RepositoryTests.Pokemon {
    [Trait("Pokemon", "Search")]
    public class PokemonSearchQueryHandlerTests {

        [Fact(DisplayName = "Should return first 10 pokemon when default query is provided")]
        public async void ShouldReturnPokemonDefaultQuery()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int>(),
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                PageNumber = 0,
                PageSize = 10
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 20; i++) {
                defaultSet.Add(new PokemonEntity());
            }

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(10);
        }

        [Fact(DisplayName = "Should return first 20 pokemon")]
        public async void ShouldReturnPokemonBasedOnPageSize()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int>(),
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                PageNumber = 0,
                PageSize = 20
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 20; i++) {
                defaultSet.Add(new PokemonEntity());
            }

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(20);
        }

        [Fact(DisplayName = "Should return 0 pokemon due to no matching results")]
        public async void ShouldReturnNoPokemon()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int>(),
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                Legendary = true,
                PageNumber = 0,
                PageSize = 10
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 20; i++) {
                defaultSet.Add(new PokemonEntity());
            }

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Should return first 10 pokemon based on type")]
        public async void ShouldReturnPokemonBasedOnType()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Type1 = "Water",
                Type2 = "Water",
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int>(),
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                PageNumber = 0,
                PageSize = 10
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 20; i++) {
                defaultSet.Add(new PokemonEntity {
                    Type1 = "",
                    Type2 = ""
                });
            }
            for (var i = 0; i < 5; i++) {
                defaultSet.Add(new PokemonEntity {
                    Type1 = "Water"
                });
            }

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(5);
        }

        [Fact(DisplayName = "Should return pokemon on certain page")]
        public async void ShouldReturnPokemonOnPage()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int>(),
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                PageNumber = 2,
                PageSize = 10
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 25; i++) {
                defaultSet.Add(new PokemonEntity());
            }
            defaultSet.Add(new PokemonEntity {
                Name = "Test"
            });

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(6);
            result.Last().Name.Should().Be("Test");
        }

        [Fact(DisplayName = "Should return first 10 pokemon with qualifier set")]
        public async void ShouldReturnPokemonWithQualifier()
        {
            var mockGenericRepository = new Mock<IGenericRepository<PokemonEntity>>();
            var mapperConfig = new MapperConfiguration(options => {
                options.CreateMap<PokemonEntity, PokemonModel>();
            });
            var mapper = mapperConfig.CreateMapper();
            var query = new PokemonEntitySearchQuery {
                Number = new Dictionary<string, int>(),
                Total = new Dictionary<string, int>(),
                Hp = new Dictionary<string, int> {
                    ["lte"] = 100
                },
                Attack = new Dictionary<string, int>(),
                Defense = new Dictionary<string, int>(),
                SpAttack = new Dictionary<string, int>(),
                SpDefense = new Dictionary<string, int>(),
                Speed = new Dictionary<string, int>(),
                Generation = new Dictionary<string, int>(),
                PageNumber = 0,
                PageSize = 10
            };
            var defaultSet = new List<PokemonEntity>();
            for (var i = 0; i < 20; i++) {
                defaultSet.Add(new PokemonEntity {
                    Hp = 200
                });
            }

            for (var i = 0; i < 10; i++) {
                defaultSet.Add(new PokemonEntity {
                    Hp = 95
                });
            }

            var mockSet = defaultSet.AsQueryable().BuildMock();

            mockGenericRepository.Setup(x => x.GetAll()).Returns(mockSet.Object);

            var pokemonRepository = new PokemonRepository(mockGenericRepository.Object, mapper);
            var result = await pokemonRepository.SearchPokemonAsync(query);

            result.Should().NotBeNull();
            result.Should().HaveCount(10);
        }
    }
}