using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EgnValidator.App
{
    public class Validator : IValidator
    {
        public bool Validate(string egnInput, Dictionary<string, bool> egnValidationLog)
        {
            if (string.IsNullOrWhiteSpace(egnInput))
            {
                return false;
            }

            if (egnInput.Length != 10)
            {
                return false;
            }

            var birthDate = egnInput.Substring(0, 6);
            var isBirthDateValid = DateTime.TryParseExact(birthDate, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDatetime);

            if (isBirthDateValid == false)
            {
                return false;
            }

            return true;
        }
    }
}
