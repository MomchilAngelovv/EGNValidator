namespace EgnValidator.App
{
    using System.Collections.Generic;

    using EgnValidator.App.Models;

    public interface IValidator
    {
        bool Validate(string egn, IDictionary<string, bool> egnValidationLog, IList<Person> personLog);
    }
}
