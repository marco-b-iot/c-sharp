using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Person
    {
        static string _nome;
        static string _cognome;

        public static string Saluta(string nome, string cognome)
        {
            string salutoDellaPersona = "Ciao " + nome + " " + cognome;

            return salutoDellaPersona;
        }
    }
}
