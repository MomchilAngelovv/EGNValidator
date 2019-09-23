using EgnValidator.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.App
{
    public interface IValidator
    {
        bool Validate(string egn, IDictionary<string, bool> egnValidationLog, IList<Person> personLog);
    }
}
