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

        public Task<List<Movie>> GetAllAsync()
        {
            lock (db.Movies)
            {
                return Task.FromResult(db.Movies.OrderBy(m => m.Id).ToList());
            }
        }

        public Task<Movie?> GetByIdAsync(int id)
        {
            lock (db.Movies)
            {
                return Task.FromResult(db.Movies.FirstOrDefault(m => m.Id == id));
            }
        }

        public Task AddAsync(Movie movie)
        {
            lock (db.Movies)
            {
                movie.Id = db.Movies.Count == 0 ? 1 : db.Movies.Max(m => m.Id) + 1;
                db.Movies.Add(movie);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Movie movie)
        {
            lock (db.Movies)
            {
                var index = db.Movies.FindIndex(m => m.Id == movie.Id);
                if (index >= 0) db.Movies[index] = movie;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Movie movie)
        {
            lock (db.Movies)
            {
                db.Movies.Remove(movie);
            }
            return Task.CompletedTask;
        }
    }
}
