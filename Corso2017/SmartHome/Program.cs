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
            Lamp salonLamp = new Lamp("Salon");
            //salon.Room = "Salon";
            //string status = salon.IsOn ? "on" : "off";

            WriteStatus(salonLamp);
            salonLamp.TurnOn();
            WriteStatus(salonLamp);
        
            Lamp kitchenLamp = new Lamp("Kitchen");
            WriteStatus(kitchenLamp);

            Lamp kitchenBackup = kitchenLamp;
            kitchenLamp = salonLamp;
            kitchenLamp.TurnOff();

            WriteStatus(salonLamp);

            Console.ReadLine();
        }

        private static void WriteStatus(Lamp lamp)
        {
            Console.WriteLine($"{ lamp.Room } lamp is { lamp.Status }");
        }
    }
}
