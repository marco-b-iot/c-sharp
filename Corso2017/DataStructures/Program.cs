using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        private const string END_SUM = "=";

        enum InputResult { Number, Equals, Error }
        enum NumberType { Even, Odd }
        
        static void Main(string[] args)
        {
            //ArrayList addends = new ArrayList();
            List<int> addends = new List<int>();

            int sum = 0;

            while (true)
            {
                Console.WriteLine($"Inserisci l'addendo ('=' per effettuare la somma)");
                string input = Console.ReadLine();
                int number;
                InputResult result = VerifyInput(input, out number);

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

            Console.WriteLine($"I numeri pari inseriti sono: { string.Join(", ", GetNumbers(NumberType.Even, addends)) }");
            Console.WriteLine($"I numeri dispari inseriti sono: { string.Join(", ", GetNumbers(NumberType.Odd, addends)) }");

            Console.ReadLine();
        }

        private static List<int> GetNumbers(NumberType numberType, List<int> addends)
        {
            int modResult = numberType == NumberType.Even ? 0 : 1;

            List<int> selectedNumbers = new List<int>();

            //for (int i = 0; i < addends.Count; i++)
            //{
            //    if (addends[i] % 2 == modResult)
            //        selectedNumbers.Add(addends[i]);
            //}

            //int count = 0;
            foreach (int addend in addends)
            {
                //if (count < 40)
                //{
                //    count++;
                //    continue;
                //}

                if (Math.Abs(addend % 2) == modResult)
                    selectedNumbers.Add(addend);
            }

            return selectedNumbers;
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
