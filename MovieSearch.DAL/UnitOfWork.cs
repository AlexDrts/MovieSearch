using MovieSearch.DAL.Entities;
using MovieSearch.DAL.Interfaces;
using MovieSearch.DAL.Repositories;

namespace MovieSearch.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext db;

        public IRepository<Movie> Movies { get; private set; }

        public UnitOfWork(MovieDbContext context)
        {
            db = context;
            Movies = new Repository<Movie>(db);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
