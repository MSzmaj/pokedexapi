using Microsoft.AspNetCore.Mvc;
using PokedexApi.Common.Query;
using PokedexApi.Service.Services.Pokemon;
using System.Threading.Tasks;
using AutoMapper;
using PokedexApi.Api.Common.Filters;
using PokedexApi.Api.InputModels;

namespace PokedexApi.Api.Controllers {
	[ApiController]
	[ServiceFilter(typeof(ExceptionFilter))]
	public class PokemonController : ControllerBase {
		private readonly IQueryHandler<PokemonSearchQuery, PokemonSearchResult> _pokemonSearchHandler;
		private readonly IMapper _mapper;

		public PokemonController (
				IQueryHandler<PokemonSearchQuery, PokemonSearchResult> pokemonSearchHandler,
				IMapper mapper) {
			_pokemonSearchHandler = pokemonSearchHandler;
			_mapper = mapper;
		}

		[Route("api/health")]
		[HttpGet]
		public IActionResult HealthCheck () {
			return Ok("TEST");
		}

		/// <summary>
		/// Returns a list of Pokemon based on search criteria
		/// </summary>
		/// <remarks>
		/// Sample request: `/pokemon?hp[gte]=100`
		/// </remarks>
		/// <param name="searchCriteria"></param>
		/// <returns>A list of Pokemon</returns>
		/// <response code="200">Returns list of Pokemon</response>d
		[Route("api/pokemon")]
		[HttpGet]
		public async Task<IActionResult> SearchPokemonAsync ([FromQuery] PokemonSearchCriteria searchCriteria) {
			var query = _mapper.Map<PokemonSearchQuery>(searchCriteria);
			var result = await _pokemonSearchHandler.HandleAsync(query);
			return Ok(result);
		}
	}
}
