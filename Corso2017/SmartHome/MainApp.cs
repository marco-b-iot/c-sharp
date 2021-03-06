﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class MainApp
    {
        LampsController _lightMan;

        public MainApp(LampsController lightMan)
        {
            _lightMan = lightMan;
        }

        public void Start()
        {
            bool end = false;
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

        private bool Execute(string command)
        {
            bool end = false;
            LampsController.OperationResult result = LampsController.OperationResult.Success;

            switch (command)
            {
                case "a":
                    string l = Ask("Nome della luce da aggiungere?");
                    result = _lightMan.AddLamp(l);
                    PrintResult(result);
                    break;
                case "r":
                    l = Ask("Nome della luce da eliminare?");
                    result = _lightMan.RemoveLamp(l);
                    PrintResult(result);
                    break;
                case "l":
                    List<string> lamps;
                    result = _lightMan.GetLampsName(out lamps);
                    Console.WriteLine(string.Join("\n", lamps));
                    PrintResult(result);
                    break;
                case "ls":
                    List<LampsController.LampInfo> lampsStatus = new List<LampsController.LampInfo>();
                    result = _lightMan.GetLampsStatus(out lampsStatus);
                    Console.WriteLine(string.Join("\n", lampsStatus));
                    PrintResult(result);
                    break;
                case "on":
                    l = Ask("Nome della luce da accendere?");
                    result = _lightMan.TurnOn(l);
                    PrintResult(result);
                    break;
                case "off":
                    l = Ask("Nome della luce da spegnere?");
                    result = _lightMan.TurnOff(l);
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

        private string Ask(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        private void PrintMenu()
        {
            Console.WriteLine("a - Aggiungi luce");
            Console.WriteLine("r - Rimuovi luce");
            Console.WriteLine("l - Lista luci");
            Console.WriteLine("ls - Lista stato luci");
            Console.WriteLine("on - Accendi luce");
            Console.WriteLine("off - Spegni luce");
        }
    }
}
