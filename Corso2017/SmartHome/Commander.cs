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

        public enum Commands { AddLamp, RemoveLame, ListLamps, ListLampsStatus, SwitchOn, SwitchOff}

        public LampsController.OperationResult Execute(Commands command, string lightName)
        {
            bool end = false;
            LampsController.OperationResult result = LampsController.OperationResult.Success;
            switch (command)
            {
                case Commands.AddLamp:
                    result = _lampsController.AddLamp(lightName);
                    break;
                case Commands.RemoveLame:
                    result = _lampsController.RemoveLamp(lightName);
                    break;
                case Commands.ListLamps:
                    List<string> lamps;
                    result = _lampsController.GetLampsName(out lamps);
                    break;
                case Commands.ListLampsStatus:
                    result = _lampsController.GetLampsStatus(out lamps, ": ");
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
            return result;

        }

        Commander(LampsController lampController)
        {
            _lampsController = lampController;
        }

    }
}
