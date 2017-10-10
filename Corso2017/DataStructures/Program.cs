using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        private const string END_SUM = "=";

        enum InputResult { Number, Equals, Error }
        
        static void Main(string[] args)
        {
            //ArrayList addends = new ArrayList();
            List<int> addends = new List<int>();

            int sum = 0;

            while (true)
            {
                Console.WriteLine($"Inserisci l'addendo ('=' per effettuare la somma)");
                string input = Console.ReadLine();
                InputResult result = VerifyInput(input, out int number);

                if (result == InputResult.Equals)
                {
                    break;
                }
                else if (result == InputResult.Number)
                {
                    addends.Add(number);
                    sum += number;
                }
                else
                {
                    Console.WriteLine("Non hai inserito un numero intero");
                }
            }

            Console.WriteLine(string.Format("La somma è {0} e ho sommato {1} addendi", sum, addends.Count));

            Console.ReadLine();
        }

        private static InputResult VerifyInput(string input, out int number)
        {
            InputResult result = InputResult.Error;

            if (input == END_SUM)
            {
                number = 0;
                result = InputResult.Equals;
            }
            else if (int.TryParse(input, out number))
            {
                result = InputResult.Number;
            }

            return result;
        }


        //private static void VerifyInput(ref int sum, out int originalValue)
        //{
        //    originalValue = sum;
        //    sum += 10;
        //}
    }
}
