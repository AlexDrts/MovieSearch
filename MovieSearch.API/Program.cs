using System.Text.Encodings.Web;
using System.Text.Unicode;
using MovieSearch.BLL;

namespace MovieSearch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
