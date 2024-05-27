using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class PasswordValidationRule : ValidationRule
    {
        /// <summary>
        /// Validates the specified value to ensure it contains only numeric characters.
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

            if (!Regex.IsMatch(input, @"^\d+$"))
            {
                return new ValidationResult(false, "Field must contain only numeric characters.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
