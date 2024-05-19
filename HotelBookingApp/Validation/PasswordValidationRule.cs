using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }

            if (!Regex.IsMatch(input, @"^[0-9]+$"))
            {
                return new ValidationResult(false, "Field must contain only numeric characters");
            }
            return ValidationResult.ValidResult;
        }
    }
}
