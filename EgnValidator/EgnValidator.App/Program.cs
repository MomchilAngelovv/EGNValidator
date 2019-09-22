using System;
using System.Collections.Generic;

namespace EgnValidator.App
{
    public class Program
    {
        static void Main()
        {
            var validator = new Validator();
            var egnValidationLog = new Dictionary<string, bool>();

            var inputEgn = Console.ReadLine();

            while (inputEgn != "stop")
            {
                if (egnValidationLog.ContainsKey(inputEgn))
                {
                    Console.WriteLine(egnValidationLog[inputEgn]);
                    continue;
                }

                var isEgnValid = validator.Validate(inputEgn, egnValidationLog);
                egnValidationLog[inputEgn] = isEgnValid;

                inputEgn = Console.ReadLine();
            }

            foreach (var egnPair in egnValidationLog)
            {
                Console.WriteLine($"{egnPair.Key} -> {egnPair.Value}");
            }
        }
    }
}
