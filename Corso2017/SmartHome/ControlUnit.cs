using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class LampsController
    {
        private List<Lamp> _lamps;

        public class LampInfo
        {
            public string Name { get; private set; }
            public string Status { get; private set; }
            public LampInfo(string lampName, string status)
            {
                Name = lampName;
                Status = status;
            }
            public override string ToString()
            {
                return $"{Name}: {Status}";
            }
        }

        public enum OperationResult { AlreadyExists, NotExists, Success, Empty, InvalidName}

        public OperationResult AddLamp(string roomName)
        {
            OperationResult r;

            if (!ExistLamp(roomName) && CheckValidName(roomName))
            {
                _lamps.Add(new Lamp(roomName));
                r = OperationResult.Success;
            }
            else if (!CheckValidName(roomName))
            {
                r = OperationResult.InvalidName;
            }
            else
            {
                r = OperationResult.AlreadyExists;
            }

            return r;
        }

        private bool CheckValidName(string name)
        {
            bool validName = true;
            if (name.StartsWith(" ") || (name == "") || name.EndsWith(" "))
            {
                validName = false;
            }
            return validName;
        }

        public OperationResult RemoveLamp(string roomName)
        {
            OperationResult r;
          
            if (ExistLamp(roomName))
            {
                _lamps.Remove(GetLamp(roomName));
                r = OperationResult.Success;          
            }
            else if (IsEmpty)
            {
                r = OperationResult.Empty;
            } else
            {
                r = OperationResult.NotExists;
            }
            return r;
        }

        private bool ExistLamp(string roomName)
        {
            return (GetLamp(roomName) != null);
        }

        public OperationResult GetLampsName(out List<string> lampNames)
        {
            lampNames = new List<string>();
            OperationResult result = (IsEmpty) ? OperationResult.Empty : OperationResult.Success;
            foreach (var lamp in _lamps)
            {
                lampNames.Add(lamp.Room);
            }
            return result;
        }

        private bool IsEmpty
        {
            get
            {
                return _lamps.Count == 0;
            }
        }
        
        public OperationResult GetLampsStatus(out List<LampInfo> lampAndStatus)
        {
            lampAndStatus = new List<LampInfo>();
            OperationResult result = (_lamps.Count == 0) ? OperationResult.Empty : OperationResult.Success;
           
            foreach (var lamp in _lamps)
            {
                lampAndStatus.Add(new LampInfo(lamp.Room, lamp.Status));
            }
            return result;
        }

        private Lamp GetLamp(string roomName)
        {
            Lamp found = null;
            foreach (Lamp l in _lamps)
            {
                if (l.Room == roomName)
                {
                    found = l;
                }
            }
            return found;
        }

        public OperationResult TurnOn(string roomName)
        {
            OperationResult r = OperationResult.NotExists;
            
            if (ExistLamp(roomName))
            {
                GetLamp(roomName).TurnOn();
                r = OperationResult.Success;
            }
            return r;
        }

        public OperationResult TurnOff(string roomName)
        {
            OperationResult r = OperationResult.NotExists;
            if (ExistLamp(roomName))
            {
                GetLamp(roomName).TurnOff();
                r = OperationResult.Success;
            }
            return r;
        }

        public LampsController()
        {
            _lamps = new List<Lamp>();
        }


    }
}
