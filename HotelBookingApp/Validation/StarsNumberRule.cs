using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class StarsNumberRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Field cannot be empty.");
            }

            if (!int.TryParse(value.ToString(), out int starsNumber))
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
