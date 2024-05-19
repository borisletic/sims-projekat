using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
        public class IntegerNumberValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string input = value as string;

                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int result) || result <= 0)
                {
                    return new ValidationResult(false, "Number of guests should be a positive integer value.");
                }

                return ValidationResult.ValidResult;
            }
        }
 
}
