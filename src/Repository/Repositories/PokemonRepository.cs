using PokedexApi.Interface.Interfaces.Repositories;
using System.Threading.Tasks;
using PokedexApi.DataAccess.Interfaces;
using AutoMapper;
using PokedexApi.DataAccess.EntityModels.Pokemon;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PokedexApi.Interface.Models.Pokemon;
using LinqKit;
using PokedexApi.Common.Extensions;
using System.Linq.Expressions;
using System;

namespace PokedexApi.Repostory.Repositories {
    public class PokemonRepository : IPokemonRepository {
        private readonly IGenericRepository<PokemonEntity> _genericPokemonRepository;

        private readonly IMapper _mapper;

        public PokemonRepository (IGenericRepository<PokemonEntity> genericPokemonRepository,
                                IMapper mapper) {
                                    _genericPokemonRepository = genericPokemonRepository;
                                    _mapper = mapper;
                                }

        public async Task<IEnumerable<PokemonModel>> SearchPokemonAsync(PokemonEntitySearchQuery query) {
            var predicate = BuildSearchPredicate(query);
            var result = await _genericPokemonRepository.GetAll().AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Number)
                .Skip(query.PageNumber * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PokemonModel>>(result);
        }

        private ExpressionStarter<PokemonEntity> BuildSearchPredicate (PokemonEntitySearchQuery query) {
            var predicate = PredicateBuilder.New<PokemonEntity>(true);

            predicate = !string.IsNullOrEmpty(query.Name) ? predicate.And(x => x.Name.ToLower() == query.Name.ToLower()) : predicate;
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Number, predicate, x => x.Number); 
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Total, predicate, x => x.Total);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Hp, predicate, x => x.Hp);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Attack, predicate, x => x.Attack);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Defense, predicate, x => x.Defense);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.SpAttack, predicate, x => x.SpAttack);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.SpDefense, predicate, x => x.SpDefense);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Speed, predicate, x => x.Speed);
            predicate = CreateComparisonPredicate<PokemonEntity>(query.Generation, predicate, x => x.Generation);
            predicate = predicate.And(x => x.Legendary == query.Legendary);

            if (!string.IsNullOrEmpty(query.Type1)) {
                predicate = predicate.And(x => x.Type1.ToLower() == query.Type1.ToLower() || x.Type2.ToLower() == query.Type1.ToLower());
            }

            if (!string.IsNullOrEmpty(query.Type2)) {
                predicate = predicate.And(x => x.Type1.ToLower() == query.Type2.ToLower() || x.Type2.ToLower() == query.Type2.ToLower());
            }

            return predicate;
        }

        private Expression<Func<T, bool>> CreateComparisonPredicate<T> (Dictionary<string, int> dict, 
                                                              ExpressionStarter<T> predicate, 
                                                              Expression<Func<T, int>> target) {
            if (dict.Count() > 0) {
                var key = dict.Keys.FirstOrDefault();
                var value = dict[key];

                predicate = predicate.And(key.CompareUsingOperator<T>(value, target)); 
            }

            return predicate;
        }
    }
}