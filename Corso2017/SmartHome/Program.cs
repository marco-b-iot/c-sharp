using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Program
    {
        
        static void Main(string[] args)
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

        private static bool Execute(string command, LampsController lightMan)
        {
            bool end = false;
            LampsController.OperationResult result = LampsController.OperationResult.Success;

            switch (command)
            {
                case "a":
                    string l = Ask("Nome della luce da aggiungere?");
                    result = lightMan.AddLamp(l);
                    PrintResult(result);
                    break;
                case "r":
                    l = Ask("Nome della luce da eliminare?");
                    result = lightMan.RemoveLamp(l);
                    PrintResult(result);
                    break;
                case "l":
                    List<string> lamps;
                    result = lightMan.GetLampsName(out lamps);
                    Console.WriteLine(string.Join("\n", lamps));
                    PrintResult(result);
                    break;
                case "ls":
                    result = lightMan.GetLampsStatus(out lamps, ": ");
                    Console.WriteLine(string.Join("\n", lamps));
                    PrintResult(result);
                    break;
                case "on":
                    l = Ask("Nome della luce da accendere?");
                    result = lightMan.TurnOn(l);
                    PrintResult(result);
                    break;
                case "off":
                    l = Ask("Nome della luce da spegnere?");
                    result = lightMan.TurnOff(l);
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

        

        

        

        private static void WriteStatus(Lamp lamp)
        {
            Console.WriteLine($"{ lamp.Room } lamp is { lamp.Status }");
        }
        
    }
}
