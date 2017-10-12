using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class Person
    {
        string _nome;
        //string _cognome;

        public string Nome
        {
            get
            {
                return _nome;
            }
            private set
            {
                _nome = value;
            }
        }

        public string Cognome { get; private set; }

        //private void SetNome(string value)
        //{
        //    _nome = value;
        //}

        //public string GetNome()
        //{
        //    return _nome;
        //}

        public int NumeroMani { get; set; }

        public string Saluta(string nome, string cognome)
        {
            string salutoDellaPersona = "Ciao " + nome + " " + cognome;

            return salutoDellaPersona;
        }
    }
}
