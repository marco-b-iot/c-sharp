
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Model;

namespace CSharp
{
    class Program
    {
        /// <summary>
        /// Entry point dell'applicazione
        /// </summary>
        /// <param name="args">Parametri di avvio</param>
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
            string ciao = Person.Saluta("Mario", "Rossi");
           
            CSharp.Model.Book.Open();

            Debug.WriteLine("Eseguito DO");
        }
    }
}
