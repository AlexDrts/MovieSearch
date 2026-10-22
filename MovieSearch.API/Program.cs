using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore;
using MovieSearch.BLL;
using MovieSearch.DAL;
using MovieSearch.DAL.Interfaces;

namespace MovieSearch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connection))
                builder.Services.AddDbContext<MovieDbContext>(options => options.UseInMemoryDatabase("Movies"));
            else
                builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connection));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddBusinessLogic();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All));

            builder.Services.AddCors(options =>
                options.AddDefaultPolicy(policy =>
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();

            app.UseCors();

            app.UseStaticFiles();

            app.MapGet("/", () => Results.Redirect("/api/movies"));

            app.MapControllers();

            app.Run();
        }
    }
}
