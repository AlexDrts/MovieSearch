using MovieSearch.BLL.DTOs;

namespace MovieSearch.BLL.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllAsync();
        Task<MovieDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(MovieDto dto);
        Task<bool> UpdateAsync(int id, MovieDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
