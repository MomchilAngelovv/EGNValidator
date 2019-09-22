using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EgnValidator.App
{
    public class Validator : IValidator
    {
        public bool Validate(string egnInput)
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

            try
            {
                var isBirthDateValid = DateTime.ParseExact(birthDate, "yyMMdd", CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {
                return false;
            }

            ;
            throw new NotImplementedException();
        }
    }
}
