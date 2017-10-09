using System;
using System.Collections;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList addends = new ArrayList();

            int sum = 0;

            while (true)
            {
                Console.WriteLine($"Inserisci l'addendo ('=' per effettuare la somma)");
                string input = Console.ReadLine();
                if (input == "=")
                {
                    break;
                }
                else
                {
                    int addend = int.Parse(input);
                    addends.Add(addend);
                    sum += addend;
                }
            }

            Console.WriteLine(string.Format("La somma è {0} e ho sommato {1} addendi", sum, addends.Count));

            Console.ReadLine();
        }
    }
}
