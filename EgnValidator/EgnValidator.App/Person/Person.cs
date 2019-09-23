using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.App.Person
{
    public class Person
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public PersonSex Sex { get; set; }
    }
}
