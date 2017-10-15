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
            LampsController lampController = new LampsController();
            MainApp app = new MainApp(lampController);
            app.Start();       
        }

        
    }
}
