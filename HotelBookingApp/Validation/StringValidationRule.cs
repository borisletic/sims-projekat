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
    public class StringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input;

            if (value is string)
            {
                input = (string)value;
            }
            else if (value is int intValue)
            {
                input = intValue.ToString();
            }
            else
            {
                return new ValidationResult(false, "Unsupported input type");
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }

            if (!Regex.IsMatch(input, "^[a-zA-Z]+$"))
            {
                return new ValidationResult(false, "Field requires only letters");
            }

            return ValidationResult.ValidResult;
        }
    }

}
