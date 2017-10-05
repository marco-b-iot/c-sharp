
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Do();

            string nome = "Mario";
            Console.WriteLine(nome);

            string nome2 = nome;
            Console.WriteLine(nome2);
            
            nome = "Giovanni";
            Console.WriteLine(nome2);

            Console.ReadLine();
        }

        private static void Do()
        {
            Debug.WriteLine("Eseguito DO");
        }
    }
}
