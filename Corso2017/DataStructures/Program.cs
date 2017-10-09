using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quanti numeri vuoi sommare?");
            string addendsNumber = Console.ReadLine();

            int[] addends = new int[int.Parse(addendsNumber)];

            int sum = 0;
            for (int i = 0; i < addends.Length; i++)
            {
                Console.WriteLine($"Inserisci l'addendo {i + 1} di { addends.Length }");
                string addend = Console.ReadLine();
                addends[i] = int.Parse(addend);

                sum += addends[i];
            }

            Console.WriteLine(string.Format("La somma è {0} e ho sommato {1} addendi", sum, addendsNumber));

            Console.ReadLine();
        }
    }
}
