using EgnValidator.App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EgnValidator.App
{
    public class Validator : IValidator
    {
        private readonly int[] digitMultiplierCoeficients = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public bool Validate(string egnInput, IDictionary<string, bool> egnValidationLog, IList<Person> peopleLog)
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
            var personSexDigit = int.Parse(egnInput[8].ToString());
            var checkSumDigit = int.Parse(egnInput[9].ToString());

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

            var isBirthDateValid = DateTime.TryParseExact(birthDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedBirthdate);

            if (isBirthDateValid == false)
            {
                return false;
            }

            var personSex = personSexDigit % 2 == 0 ? PersonSex.Male : PersonSex.Female;

            var person = new Person
            {
                Id = Guid.NewGuid().ToString(),
                Birthdate = parsedBirthdate,
                Sex = personSex
            };

            var checkSum = 0;

            for (int i = 0; i < egnInput.Length - 1; i++)
            {
                checkSum += int.Parse(egnInput[i].ToString()) * digitMultiplierCoeficients[i];
            }

            checkSum %= 11;

            if (checkSum == 10)
            {
                checkSum = 0;
            }

            if (checkSum != checkSumDigit)
            {
                return false;
            }

            peopleLog.Add(person);

            return true;
        }
    }
}
