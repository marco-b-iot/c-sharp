using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            Console.WriteLine("Length: " + numbers.Length);
            Console.WriteLine("numbers[0] = " + numbers[0]);
            numbers[2] = 5;
            Console.WriteLine("numbers[2] = " + numbers[2]);

            Console.ReadLine();
        }
    }
}
