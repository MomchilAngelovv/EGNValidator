namespace EgnValidator.App
{
    using System;
    using System.Collections.Generic;

    using EgnValidator.App.Models;

    public class Program
    {
        public static void Main()
        {
            var validator = new Validator();
            var inputEgnLog = new Dictionary<string, bool>();
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

                if (inputEgn == "show log")
                {
                    ShowInputEgnLog(inputEgnLog);
                    continue;
                }

                if (inputEgnLog.ContainsKey(inputEgn))
                {
                    Console.WriteLine($"Person with this Egn already exists.");
                    continue;
                }

                var isEgnValid = validator.Validate(inputEgn, inputEgnLog, peopleLog);
                inputEgnLog[inputEgn] = isEgnValid;

                if (isEgnValid)
                {
                    Console.WriteLine("Egn registered in valid EGN log.");
                    continue;
                }

                Console.WriteLine("Invalid Egn.");
            }

            ShowInputEgnLog(inputEgnLog);
        }

        private static void ShowInputEgnLog(IDictionary<string, bool> inputEgnLog)
        {
            Console.WriteLine($"{new string('=', 50)}");
            foreach (var pair in inputEgnLog)
            {
                var egnState = pair.Value == true ? "Valid" : "Invalid";
                Console.WriteLine($"Egn: {pair.Key}: {egnState}");
            }
            Console.WriteLine($"{new string('=', 50)}");
        }

        private static void ShowRegisteredPeople(IList<Person> peopleLog)
        {
            Console.WriteLine($"{new string('=', 50)}");
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
            Console.WriteLine($"1.show - show registered people log.");
            Console.WriteLine($"1.show log - show Egn log.");
            Console.WriteLine($"{new string('=', 50)}");
            Console.WriteLine($"Please enter EGN to check if it is valid:");
        }
    }
}
