using Microsoft.Extensions.DependencyInjection;
using MovieSearch.BLL.Interfaces;
using MovieSearch.BLL.Services;

namespace MovieSearch.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
