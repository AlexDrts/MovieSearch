using Microsoft.Extensions.DependencyInjection;
using MovieSearch.BLL.Interfaces;
using MovieSearch.BLL.Services;
using MovieSearch.DAL;
using MovieSearch.DAL.Interfaces;
using MovieSearch.DAL.Repositories;

namespace MovieSearch.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddSingleton<MovieContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
