using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        private static readonly Regex PhoneRegex = new Regex(@"^\d{10}$", RegexOptions.Compiled);

        /// <summary>
        /// Validates the specified value to ensure it is a valid 10-digit phone number.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string input || string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Phone number cannot be empty.");
            }

            if (!PhoneRegex.IsMatch(input))
            {
                return new ValidationResult(false, "Invalid phone number format. Must be exactly 10 digits.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
