using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    //public class Environments
    //{
    //    public const string TEST = "test";
    //    public const string PRODUZIONE = "prod";
    //}

    public enum Environments
    {
        /// <summary>
        /// Test
        /// </summary>
        Test,

        /// <summary>
        /// Produzione
        /// </summary>
        Produzione
    }

    class Program
    {
        private const string TEST_SERVICE_URL = "http://test.google.com/?q=testquery";
        private const string PROD_SERVICE_URL = "http://www.google.com/?q=testquery";

        private static readonly string SERVICE_URL = CreateServiceUrl(Environments.Test);

        private static string CreateServiceUrl(Environments environment)
        {
            string url = string.Empty;
            
            if (environment == Environments.Test)
            {
                url = TEST_SERVICE_URL;
            }
            else if (environment == Environments.Produzione)
            {
                url = PROD_SERVICE_URL;
            }

            return url;
        }

        static void Main(string[] args)
        {
            CallService();
            CallService(Environments.Test);
        }

        private static void CallService()
        {
            Console.WriteLine("Chiamo " + SERVICE_URL);
        }

        private static void CallService(Environments environment)
        {
            if (environment == Environments.Test)
            {
                Call(TEST_SERVICE_URL);
            }
            else if (environment == Environments.Produzione)
            {
                Call(PROD_SERVICE_URL);
            }
        }

        private static void Call(string url)
        {
            //throw new NotImplementedException();
        }
    }
}
