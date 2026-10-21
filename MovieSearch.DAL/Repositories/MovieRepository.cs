using Microsoft.EntityFrameworkCore;
using MovieSearch.DAL.Entities;
using MovieSearch.DAL.Interfaces;

namespace MovieSearch.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext db;

        public MovieRepository(MovieContext context)
        {
            db = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await db.Movies.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Movie movie)
        {
            db.Movies.Add(movie);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            db.Movies.Update(movie);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
        }
    }
}
