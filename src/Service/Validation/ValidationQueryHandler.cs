using System.Threading.Tasks;
using FluentValidation;
using PokedexApi.Common.Query;

namespace PokedexApi.Service.Validation {
    public class ValidationQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> {
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;
        private readonly IValidator<TQuery> _validator;

        public ValidationQueryHandler (
                IQueryHandler<TQuery, TResult> queryHandler,
                IValidator<TQuery> validator) {
            _queryHandler = queryHandler;
            _validator = validator;
        }

        public async Task<TResult> HandleAsync(TQuery query)
        {
            await _validator.ValidateAsync(query, options => {
                options.ThrowOnFailures();
            });
            return await _queryHandler.HandleAsync(query);
        }
    }
}