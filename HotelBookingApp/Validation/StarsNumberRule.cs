using System.Globalization;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class StarsNumberRule: ValidationRule
    {
        /// <summary>
        /// Validates the specified value to ensure it is a valid star rating between 1 and 5.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string input || string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty.");
            }

            if (!int.TryParse(input, out int starsNumber))
            {
                return new ValidationResult(false, "Invalid input. Please enter a number.");
            }

            if (starsNumber < 1 || starsNumber > 5)
            {
                return new ValidationResult(false, "Invalid star rating. Please enter a number between 1 and 5.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
