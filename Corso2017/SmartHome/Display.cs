using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Display
    {
        const string ADD_LIGHT = "a";
        const string REMOVE_LIGHT = "r";
        const string LIST_LIGHT = "l";
        const string LIST_STATUS_LIGHT = "ls";
        const string ON_LIGHT = "on";
        const string OFF_LIGHT = "off";
        const string EXIT = "exit";

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
            Console.WriteLine($"{ADD_LIGHT} \t Aggiungi luce");
            Console.WriteLine($"{REMOVE_LIGHT} \t Rimuovi luce");
            Console.WriteLine($"{LIST_LIGHT} \t Lista luci");
            Console.WriteLine($"{LIST_STATUS_LIGHT} \t Lista stato luci");
            Console.WriteLine($"{ON_LIGHT} \t Accendi luce");
            Console.WriteLine($"{OFF_LIGHT} \t Spegni luce");
            Console.WriteLine($"{EXIT} \t Esci");
            Console.WriteLine($"Enter per confermanre il comando");
        }

        private bool Execute(string stringCommand)
        {
            bool endCommand = false;

            switch (stringCommand)
            {
                case ADD_LIGHT:
                    string l = Ask("Nome della luce da aggiungere?");
                    _commander.Execute(Commander.Commands.AddLamp, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case REMOVE_LIGHT:
                    l = Ask("Nome della luce da eliminare?");
                    _commander.Execute(Commander.Commands.RemoveLame, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case LIST_LIGHT:
                    _commander.Execute(Commander.Commands.ListLamps);
                    Console.WriteLine(string.Join("\n", _commander.OperationOutput));
                    PrintResult(_commander.OperationResult);
                    break;
                case LIST_STATUS_LIGHT:
                    _commander.Execute(Commander.Commands.ListLampsStatus);
                    Console.WriteLine(string.Join("\n", _commander.OperationOutput));
                    PrintResult(_commander.OperationResult);
                    break;
                case ON_LIGHT:
                    l = Ask("Nome della luce da accendere?");
                    _commander.Execute(Commander.Commands.SwitchOn, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case OFF_LIGHT:
                    l = Ask("Nome della luce da accendere?");
                    _commander.Execute(Commander.Commands.SwitchOff, l);
                    PrintResult(_commander.OperationResult);
                    break;
                case EXIT:
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

            while (!end)
            {
                Console.Clear();
                PrintMenu();
                string userCommand = Console.ReadLine();
                end = Execute(userCommand);
                Console.WriteLine("Premi un tasto per continuare");
                Console.ReadKey(true);
            }
        }
    }
}
