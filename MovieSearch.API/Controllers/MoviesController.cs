using Microsoft.AspNetCore.Mvc;
using MovieSearch.API.Models;
using MovieSearch.BLL.DTOs;
using MovieSearch.BLL.Interfaces;

namespace MovieSearch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IFileService fileService;

        public MoviesController(IMovieService movieService, IFileService fileService)
        {
            this.movieService = movieService;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetAll()
        {
            return await movieService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> Create(MovieRequest request)
        {
            var id = await movieService.CreateAsync(ToDto(request));
            var movie = await movieService.GetByIdAsync(id);
            return CreatedAtAction(nameof(GetById), new { id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDto>> Update(int id, MovieRequest request)
        {
            if (!await movieService.UpdateAsync(id, ToDto(request))) return NotFound();
            return await movieService.GetByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await movieService.DeleteAsync(id)) return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/poster")]
        public async Task<ActionResult<MovieDto>> UploadPoster(int id, [FromForm] PosterUploadRequest request)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            movie.PosterPath = await fileService.SaveAsync(request.File!);
            await movieService.UpdateAsync(id, movie);
            return movie;
        }

        private static MovieDto ToDto(MovieRequest request) => new MovieDto
        {
            Title = request.Title,
            Director = request.Director,
            Genre = request.Genre,
            ReleaseYear = request.ReleaseYear ?? 0,
            PosterPath = request.PosterPath,
            Description = request.Description
        };
    }
}
