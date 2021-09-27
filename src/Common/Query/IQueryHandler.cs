using System.Threading.Tasks;

namespace PokedexApi.Common.Query {
    public interface IQueryHandler<TQuery, TResult> where TQuery: IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}