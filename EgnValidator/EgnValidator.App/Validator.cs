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

            var year = 1900 + int.Parse(egnInput.Substring(0, 2));
            var month = int.Parse(egnInput.Substring(2, 2));
            var day = int.Parse(egnInput.Substring(4, 2));

            if (day >= 41 && day <= 71)
            {
                day -= 40;
                year += 100;
            }

            if (month >= 21 && month <= 32)
            {
                month -= 20;
                year -= 100;
            }

            var yearAsString = year.ToString("D4");
            var monthAsString = month.ToString("D2");
            var dayAsString = day.ToString("D2");

            var birthDate = $"{yearAsString}{monthAsString}{dayAsString}";

            var isBirthDateValid = DateTime.TryParseExact(birthDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDatetime);

            if (isBirthDateValid == false)
            {
                return false;
            }

            return true;
        }
    }
}
