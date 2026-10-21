using MovieSearch.BLL.DTOs;
using MovieSearch.BLL.Interfaces;
using MovieSearch.DAL.Entities;
using MovieSearch.DAL.Interfaces;

namespace MovieSearch.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository repository;

        public MovieService(IMovieRepository movieRepository)
        {
            repository = movieRepository;
        }

        public async Task<List<MovieDto>> GetAllAsync()
        {
            var movies = await repository.GetAllAsync();
            return movies.Select(ToDto).ToList();
        }

        public async Task<MovieDto?> GetByIdAsync(int id)
        {
            var movie = await repository.GetByIdAsync(id);
            return movie == null ? null : ToDto(movie);
        }

        public async Task<int> CreateAsync(MovieDto dto)
        {
            var movie = new Movie();
            CopyToEntity(dto, movie);
            await repository.AddAsync(movie);
            return movie.Id;
        }

        public async Task<bool> UpdateAsync(int id, MovieDto dto)
        {
            var movie = await repository.GetByIdAsync(id);
            if (movie == null) return false;

            CopyToEntity(dto, movie);
            await repository.UpdateAsync(movie);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await repository.GetByIdAsync(id);
            if (movie == null) return false;

            await repository.DeleteAsync(movie);
            return true;
        }

        private static MovieDto ToDto(Movie movie) => new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            Genre = movie.Genre,
            ReleaseYear = movie.ReleaseYear,
            PosterPath = movie.PosterPath,
            Description = movie.Description
        };

        private static void CopyToEntity(MovieDto dto, Movie movie)
        {
            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Genre = dto.Genre;
            movie.ReleaseYear = dto.ReleaseYear;
            movie.PosterPath = dto.PosterPath;
            movie.Description = dto.Description;
        }
    }
}
