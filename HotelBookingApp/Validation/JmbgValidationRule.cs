using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class JmbgValidationRule: ValidationRule
    {
        /// <summary>
        /// Validates the specified value to ensure it is a valid JMBG.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string jmbg || string.IsNullOrWhiteSpace(jmbg))
            {
                return new ValidationResult(false, "Field cannot be empty.");
            }

            if (jmbg.Length != 13)
            {
                return new ValidationResult(false, "JMBG must be exactly 13 digits long.");
            }

            if (!jmbg.All(char.IsDigit))
            {
                return new ValidationResult(false, "JMBG can only contain digits.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
