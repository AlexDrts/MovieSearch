using Microsoft.AspNetCore.Http;

namespace MovieSearch.BLL.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveAsync(IFormFile file);
    }
}
