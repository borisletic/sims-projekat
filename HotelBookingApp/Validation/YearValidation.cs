using System;
using System.Globalization;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class YearValidation : ValidationRule
    {
        /// <summary>
        /// Validates the specified value to ensure it is a valid year.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>A ValidationResult indicating whether the value is valid.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string yearStr || string.IsNullOrWhiteSpace(yearStr))
            {
                return new ValidationResult(false, "Please enter a year.");
            }

            if (yearStr.Length > 4 || !int.TryParse(yearStr, out int year))
            {
                return new ValidationResult(false, "Invalid year format. Try: 1998, 2024...");
            }

            if (year > DateTime.Now.Year)
            {
                return new ValidationResult(false, "Year cannot be in the future.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
