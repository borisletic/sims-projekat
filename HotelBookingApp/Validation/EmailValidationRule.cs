using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class EmailValidationRule : ValidationRule
    {
        // Compiling the regex once for better performance
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled);

        /// <summary>
        /// Validates the specified value against the email pattern.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string input || string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field is required");
            }

            if (!EmailRegex.IsMatch(input))
            {
                return new ValidationResult(false, "Invalid email format");
            }

            return ValidationResult.ValidResult;
        }
    }
}
