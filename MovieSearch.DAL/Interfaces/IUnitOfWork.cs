using MovieSearch.DAL.Entities;

namespace MovieSearch.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        Task<int> SaveChangesAsync();
    }
}
