using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MovieSearch.BLL.Interfaces;

namespace MovieSearch.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment env;

        public FileService(IWebHostEnvironment environment)
        {
            env = environment;
        }

        public async Task<string> SaveAsync(IFormFile file)
        {
            var folder = Path.Combine(env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot"), "posters");
            Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
            using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "/posters/" + fileName;
        }
    }
}
