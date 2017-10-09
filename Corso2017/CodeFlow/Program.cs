using System;

namespace CodeFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            IfAndSwitch();

            UnaryOperators();

            ForLoops();

            WhileLoops();

            Console.ReadLine();
        }

        private static void WhileLoops()
        {
            Console.WriteLine("While loops");

            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }

            int j = 10;
            do
            {
                Console.WriteLine(j);
                j--;
            } while (j > 0);
        }

        private static void UnaryOperators()
        {
            Console.WriteLine("Unary operators");

            int number = 0;

            Console.WriteLine(number++);
            Console.WriteLine(++number);
            Console.WriteLine(number--);
            Console.WriteLine(--number);
        }

        private static void ForLoops()
        {
            Console.WriteLine("For loops");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine("Premi un tasto");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.KeyChar == 'a')
                {
                    Console.WriteLine("Hai premuto 'a'");
                    break;
                }
                else
                {
                    Console.WriteLine("Non hai premuto 'a', ritenta");
                }
            }
        }

        private static void IfAndSwitch()
        {
            Console.WriteLine("Premi un tasto");

            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == 'a')
            {
                Console.WriteLine("Hai premuto 'a'");
            }
            else if (key.KeyChar == 'b' || key.KeyChar == 'c')
            {
                Console.WriteLine("Hai premuto 'b' o 'c'");
            }
            else if (key.Key == ConsoleKey.D && key.Modifiers == ConsoleModifiers.Shift)
            {
                Console.WriteLine("Hai premuto 'D' con shift");
            }
            else
            {
                Console.WriteLine("Non Hai premuto ne 'a' ne 'b' ne 'c'");
            }

            switch (key.KeyChar)
            {
                case 'a':
                    Console.WriteLine("Hai premuto 'a'");
                    break;
                //goto case 'b' - salto ad un altro caso
                //non usare il break e accorpare più condizioni:
                case 'b':
                case 'c':
                    Console.WriteLine("Hai premuto 'b' o 'c'");
                    break;

                default:
                    Console.WriteLine("Non Hai premuto ne 'a' ne 'b' ne 'c'");
                    break;
            }
        }
    }
}
