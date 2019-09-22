using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.App
{
    public interface IValidator
    {
        bool Validate(string egn);
    }
}
