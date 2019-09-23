using System;
using System.Collections.Generic;
using EgnValidator.App;
using EgnValidator.App.Models;

namespace EgnValidator.App
{
    public class Program
    {
        static void Main()
        {
            var validator = new Validator();
            var validEgnLog = new Dictionary<string, bool>();
            var peopleLog = new List<Person>();

            ShowInstructions();

            while (true)
            {
                var inputEgn = Console.ReadLine();

                if (inputEgn == "stop")
                {
                    break;
                }

                if (inputEgn == "show")
                {
                    ShowRegisteredPeople(peopleLog);
                    continue;
                }

                if (validEgnLog.ContainsKey(inputEgn))
                {
                    Console.WriteLine($"Already registered person with this EGN.");
                    continue;
                }

                var isEgnValid = validator.Validate(inputEgn, validEgnLog, peopleLog);
                validEgnLog[inputEgn] = isEgnValid;

                if (isEgnValid)
                {
                    Console.WriteLine("Egn registered in valid EGN log.");
                    continue;
                }

                Console.WriteLine("Invalid Egn.");
            }

            foreach (var egnPair in validEgnLog)
            {
                Console.WriteLine($"{egnPair.Key} -> {egnPair.Value}");
            }
        }

        private static void ShowRegisteredPeople(IList<Person> peopleLog)
        {
            Console.WriteLine($"List of registered people with valid Egn:");
            foreach (var person in peopleLog)
            {
                Console.WriteLine($"Id: {person.Id}; Birthdate(yyyy-MM-dd): {person.Birthdate.ToString("yyyy-MM-dd")}; Sex: {person.Sex}");
            }
            Console.WriteLine($"{new string('=', 50)}");
        }

        private static void ShowInstructions()
        {
            Console.WriteLine($"Successfully started EGN validator");
            Console.WriteLine($"{new string('=',50)}");
            Console.WriteLine($"Available commands:");
            Console.WriteLine($"1.stop - stops the application and prints Egn log.");
            Console.WriteLine($"1.show - show Egn log.");
            Console.WriteLine($"{new string('=', 50)}");
            Console.WriteLine($"Please enter EGN to check if it is valid:");
        }
    }
}
