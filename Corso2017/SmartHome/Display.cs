using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Display
    {
        Commander _commander;

        public Display(Commander c)
        {
            _commander = c;
        }

        private string Ask(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        private void PrintMenu()
        {
            //Console.Clear();

            Console.WriteLine("a - Aggiungi luce");
            Console.WriteLine("r - Rimuovi luce");
            Console.WriteLine("l - Lista luci");
            Console.WriteLine("ls - Lista stato luci");
            Console.WriteLine("on - Accendi luce");
            Console.WriteLine("off - Spegni luce");
        }

        private void Execute(string operation)
        {
            switch (operation)
            {
                case "a":
                    string l = Ask("Nome della luce da aggiungere?");
                    _commander.Execute(Commander.Commands.AddLamp);
                    PrintResult(result);
                    break;
                case "r":
                    l = Ask("Nome della luce da eliminare?");
                    PrintResult(result);
                    break;
                case "l":
                    List<string> lamps;
                    Console.WriteLine(string.Join("\n", lamps));
                    PrintResult(result);
                    break;
                case "ls":
                    Console.WriteLine(string.Join("\n", lamps));
                    PrintResult(result);
                    break;
                case "on":
                    l = Ask("Nome della luce da accendere?");
                    PrintResult(result);
                    break;
                case "off":
                    l = Ask("Nome della luce da spegnere?");
                    PrintResult(result);
                    break;
                case "end":
                    end = true;
                    break;
                default:
                    Console.WriteLine("Comando non riconosciuto");
                    break;
            }
            return end;
        }

        private void PrintResult(LampsController.OperationResult result)
        {
            if (result == LampsController.OperationResult.AlreadyExists)
            {
                Console.WriteLine("La luce è già esistente");
            }
            else if (result == LampsController.OperationResult.Empty)
            {
                Console.WriteLine("Non sono ancora state inserite luci");
            }
            else if (result == LampsController.OperationResult.InvalidName)
            {
                Console.WriteLine("Il nome non può iniziare con \" \" o esser vuoto");
            }
            else if (result == LampsController.OperationResult.NotExists)
            {
                Console.WriteLine("La luce non trovata");
            }
            else
            {
                Console.WriteLine("Done.");
            }


        }

        void startDisplay(string[] args)
        {
            LampsController lightMan = new LampsController();
            bool end = false;
            //Console.ReadLine();
            while (!end)
            {
                Console.Clear();
                PrintMenu();
                string command = Console.ReadLine();
                end = Execute(command, lightMan);
                Console.ReadKey(true);
                Console.WriteLine("Premi un tasto per continuare");

            }
        }
    }
}
