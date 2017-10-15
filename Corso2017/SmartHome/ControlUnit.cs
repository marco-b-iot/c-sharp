﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class LampsController
    {
        private List<Lamp> _lamps;
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

        public OperationResult RemoveLamp(string room)
        {
            OperationResult r;
          
            if (ExistLamp(room))
            {
                _lamps.Remove(GetLamp(room));
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

        private bool ExistLamp(string room)
        {
            return (GetLamp(room) != null);
        }

        public OperationResult GetLampsName(out List<string> lamps)
        {
            lamps = new List<string>();
            OperationResult result = (IsEmpty) ? OperationResult.Empty : OperationResult.Success;
            foreach (var lamp in _lamps)
            {
                lamps.Add(lamp.Room);
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
        
        public OperationResult GetLampsStatus(out List<string> lamps, string separator=" -> ")
        {
            lamps = new List<string>();
            OperationResult result = (_lamps.Count == 0) ? OperationResult.Empty : OperationResult.Success;
           
            foreach (var lamp in _lamps)
            {
                lamps.Add($"{lamp.Room}{separator}{lamp.Status}");
            }
            return result;
        }

        private Lamp GetLamp(string room)
        {
            Lamp found = null;
            foreach (Lamp l in _lamps)
            {
                if (l.Room == room)
                {
                    found = l;
                }
            }
            return found;
        }

        public OperationResult TurnOn(string room)
        {
            OperationResult r = OperationResult.NotExists;
            
            if (ExistLamp(room))
            {
                GetLamp(room).TurnOn();
                r = OperationResult.Success;
            }
            return r;
        }

        public OperationResult TurnOff(string room)
        {
            OperationResult r = OperationResult.NotExists;
            if (ExistLamp(room))
            {
                GetLamp(room).TurnOff();
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