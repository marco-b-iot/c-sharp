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
            LampsController lampServer = new LampsController();
            Commander commander = new Commander(lampServer);
            Display commandLineDisplay= new Display(commander);
            commandLineDisplay.startDisplay();       
        }

        

        private static void WriteStatus(Lamp lamp)
        {
            Console.WriteLine($"{ lamp.Room } lamp is { lamp.Status }");
        }
        
    }
}
