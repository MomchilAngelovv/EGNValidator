using System;
using System.Collections.Generic;

namespace EgnValidator.App
{
    public class Program
    {
        static void Main()
        {
            var validator = new Validator();
            var validEgnLog = new Dictionary<string, bool>();

            ShowInstructions();

            var inputEgn = Console.ReadLine();

            while (inputEgn != "stop")
            {
                if (validEgnLog.ContainsKey(inputEgn))
                {
                    Console.WriteLine(validEgnLog[inputEgn]);
                    continue;
                }

                var isEgnValid = validator.Validate(inputEgn, validEgnLog);
                validEgnLog[inputEgn] = isEgnValid;

                if (isEgnValid)
                {
                    Console.WriteLine("Egn registered in valid EGN log.");
                }

                inputEgn = Console.ReadLine();
            }

            foreach (var egnPair in validEgnLog)
            {
                Console.WriteLine($"{egnPair.Key} -> {egnPair.Value}");
            }
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
