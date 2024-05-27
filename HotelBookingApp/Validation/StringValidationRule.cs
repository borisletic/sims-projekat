using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class StringValidationRule : ValidationRule
    {
        private static readonly Regex LettersOnlyRegex = new Regex("^[a-zA-Z]+$", RegexOptions.Compiled);

        /// <summary>
        /// Validates the specified value to ensure it contains only letters.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input;

            switch (value)
            {
                case string str:
                    input = str;
                    break;
                case int intValue:
                    input = intValue.ToString();
                    break;
                default:
                    return new ValidationResult(false, "Unsupported input type.");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty.");
            }

            if (!LettersOnlyRegex.IsMatch(input))
            {
                return new ValidationResult(false, "Field requires only letters.");
            }

            return ValidationResult.ValidResult;
        }
    }

}
