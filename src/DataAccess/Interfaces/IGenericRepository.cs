using System.Threading.Tasks;
using System;
using System.Linq;

namespace PokedexApi.DataAccess.Interfaces {
    public interface IGenericRepository<T> {
        Task<T> GetAsync (Guid id);
        IQueryable<T> GetAll ();
    }
}