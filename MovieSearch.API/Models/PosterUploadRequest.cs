using System.ComponentModel.DataAnnotations;
using MovieSearch.API.Validation;

namespace MovieSearch.API.Models
{
    public class PosterUploadRequest
    {
        [Required(ErrorMessage = "Оберіть файл постера")]
        [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp", ".gif", ErrorMessage = "Дозволені лише зображення: jpg, jpeg, png, webp, gif")]
        public IFormFile? File { get; set; }
    }
}
