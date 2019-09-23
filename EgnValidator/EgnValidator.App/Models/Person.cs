using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.App.Models
{
    public class Person
    {
        public string Id { get; set; }

        public DateTime BirthDate { get; set; }

        public PersonSex Sex { get; set; }
    }
}
