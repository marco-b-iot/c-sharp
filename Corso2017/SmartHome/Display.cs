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

        private bool Execute(string operation)
        {
            bool endCommand = false;
            switch (operation)
            {
                case "a":
                    string l = Ask("Nome della luce da aggiungere?");
                    _commander.Execute(Commander.Commands.AddLamp, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case "r":
                    l = Ask("Nome della luce da eliminare?");
                    _commander.Execute(Commander.Commands.RemoveLame, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case "l":
                    _commander.Execute(Commander.Commands.ListLamps);
                    Console.WriteLine(string.Join("\n", _commander.OperationOutput));
                    PrintResult(_commander.OperationResult);
                    break;
                case "ls":
                    _commander.Execute(Commander.Commands.ListLampsStatus);
                    Console.WriteLine(string.Join("\n", _commander.OperationOutput));
                    PrintResult(_commander.OperationResult);
                    break;
                case "on":
                    l = Ask("Nome della luce da accendere?");
                    _commander.Execute(Commander.Commands.SwitchOn, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case "off":
                    l = Ask("Nome della luce da accendere?");
                    _commander.Execute(Commander.Commands.SwitchOff, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case "end":
                    endCommand = true;
                    break;
                default:
                    Console.WriteLine("Comando non riconosciuto");
                    break;
            }
            return endCommand;
        }

        private void PrintResult(LampsController.OperationResult result)
        {
            if (result == LampsController.OperationResult.AlreadyExists)
            {
                Console.WriteLine("La luce è già esistente.");
            }
            else if (result == LampsController.OperationResult.Empty)
            {
                Console.WriteLine("Non sono presenti luci nel sistema.");
            }
            else if (result == LampsController.OperationResult.InvalidName)
            {
                Console.WriteLine("Il nome non può iniziare con \" \" o esser vuoto.");
            }
            else if (result == LampsController.OperationResult.NotExists)
            {
                Console.WriteLine("La luce non trovata.");
            }
            else
            {
                Console.WriteLine("Done.");
            }
        }

        public void startDisplay()
        {
            LampsController lightMan = new LampsController();
            bool end = false;
            //Console.ReadLine();
            while (!end)
            {
                Console.Clear();
                PrintMenu();
                string command = Console.ReadLine();
                end = Execute(command);
                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadKey(true);
            }
        }
    }
}
