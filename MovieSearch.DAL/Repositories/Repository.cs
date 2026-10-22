using Microsoft.EntityFrameworkCore;
using MovieSearch.DAL.Interfaces;

namespace MovieSearch.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MovieDbContext db;
        protected readonly DbSet<T> set;

        public Repository(MovieDbContext context)
        {
            db = context;
            set = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await set.AddAsync(entity);
        }

        public void Update(T entity)
        {
            set.Update(entity);
        }

        public void Delete(T entity)
        {
            set.Remove(entity);
        }

        public IQueryable<T> Query()
        {
            return set.AsQueryable();
        }
    }
}
