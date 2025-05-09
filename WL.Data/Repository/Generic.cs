using Microsoft.EntityFrameworkCore;
using WL.Data.Context;
using WL.Data.Repository.Interfaces;

namespace WL.Data.Repository
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        protected AppDbContext _context;

        public Generic(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
