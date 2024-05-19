using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotelBookingApp.Validation
{
    public class JmbgValidationRule: ValidationRule
    {
        private bool IsAllDigits(string value)
        {
            foreach (char c in value)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string jmbg = value as string;

            if (string.IsNullOrWhiteSpace(jmbg))
            {
                return new ValidationResult(false, "Field cannot be empty.");
            }

            if (jmbg.Length != 13)
            {
                return new ValidationResult(false, "JMBG must be exactly 13 digits long.");
            }

            if (!IsAllDigits(jmbg))
            {
                return new ValidationResult(false, "JMBG can only contain digits.");
            }

            return ValidationResult.ValidResult;
        }      
    }
}
