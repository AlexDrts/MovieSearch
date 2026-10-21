using System.ComponentModel.DataAnnotations;

namespace MovieSearch.API.Validation
{
    public class NotFutureYearAttribute : ValidationAttribute
    {
        public NotFutureYearAttribute()
        {
            ErrorMessage = "Рік не може бути більшим за поточний";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year && year > DateTime.Now.Year)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
