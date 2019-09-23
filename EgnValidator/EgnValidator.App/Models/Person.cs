namespace EgnValidator.App.Models
{
    using System;

    public class Person
    {
        public string Id { get; set; }

        public DateTime Birthdate { get; set; }

        public PersonSex Sex { get; set; }
    }
}
