using System.Globalization;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
        public class IntegerNumberValidationRule : ValidationRule
        {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string input || string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field is required.");
            }

            if (!int.TryParse(input, out int result) || result <= 0)
            {
                return new ValidationResult(false, "Number of guests should be a positive integer value.");
            }

            return ValidationResult.ValidResult;
        }

    }

}
