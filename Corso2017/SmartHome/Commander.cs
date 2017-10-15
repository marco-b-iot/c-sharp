using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Commander
    {
        LampsController _lampsController;
        LampsController.OperationResult _lastResult;
        List<string> _display;

        public enum Commands { AddLamp, RemoveLame, ListLamps, ListLampsStatus, SwitchOn, SwitchOff }

        public List<string> OperationOutput
        {
            get
            {
                return _display;
            }
        }

        public LampsController.OperationResult OperationResult
        {
            get
            {
                return _lastResult;
            }
        }


        public bool Execute(Commands command, string lightName="")
        {
            LampsController.OperationResult result = LampsController.OperationResult.Success;
            //Vuoto i risultati
            _display = new List<string>(); 

            switch (command)
            {
                case Commands.AddLamp:
                    result = _lampsController.AddLamp(lightName);
                    break;
                case Commands.RemoveLame:
                    result = _lampsController.RemoveLamp(lightName);
                    break;
                case Commands.ListLamps:
                    result = _lampsController.GetLampsName(out _display);
                    break;
                case Commands.ListLampsStatus:
                    result = _lampsController.GetLampsStatus(out _display, ": ");
                    break;
                case Commands.SwitchOn:
                    result = _lampsController.TurnOn(lightName);
                    break;
                case Commands.SwitchOff:
                    result = _lampsController.TurnOff(lightName);
                    break;
                default:
                    break;
            }
            _lastResult = result;
            return (result == LampsController.OperationResult.Success);

        }

        public Commander(LampsController lampController)
        {
            _lampsController = lampController;
        }

    }
}
