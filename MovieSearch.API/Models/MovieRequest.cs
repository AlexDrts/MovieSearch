using System.ComponentModel.DataAnnotations;
using MovieSearch.API.Validation;

namespace MovieSearch.API.Models
{
    public class MovieRequest
    {
        [Required(ErrorMessage = "Вкажіть назву")]
        [StringLength(150, ErrorMessage = "Максимум 150 символів")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Вкажіть режисера")]
        [StringLength(100, ErrorMessage = "Максимум 100 символів")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Вкажіть жанр")]
        [StringLength(100, ErrorMessage = "Максимум 100 символів")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Вкажіть рік випуску")]
        [Range(1888, 2100, ErrorMessage = "Рік має бути не раніше 1888")]
        [NotFutureYear(ErrorMessage = "Рік випуску не може бути більшим за поточний")]
        public int? ReleaseYear { get; set; }

        public string? PosterPath { get; set; }

        [Required(ErrorMessage = "Додайте опис")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Опис має містити від 10 до 2000 символів")]
        public string? Description { get; set; }
    }
}
