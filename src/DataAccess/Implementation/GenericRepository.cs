using PokedexApi.DataAccess.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PokedexApi.DataAccess.Common {
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new() {
        private readonly DbContext _context;

        public GenericRepository (DbContext context) {
            _context = context;
        }

        public async Task<T> GetAsync (Guid id) {

            var result = await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync();

            return result;
        }

        public IQueryable<T> GetAll () {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }
    }
}