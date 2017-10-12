using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class Lamp
    {
        private bool _isOn;

        public Lamp(string room /*= "N/A"*/)
        {
            //if (string.IsNullOrEmpty(room))
            //    room = "N/A";

            Room = room;
        }

        public string Room { get; private set; }
        
        //public string GetStatus()
        //{
        //    return IsOn ? "on" : "off";
        //}

        public string Status
        {
            get
            {
                return _isOn ? "on" : "off";
            }
        }

        public bool TurnOn()
        {
            _isOn = true;

            return _isOn;
        }

        public bool TurnOff()
        {
            _isOn = false;

            return _isOn;
        }

        public bool TurnOn(int intensity)
        {
            _isOn = true;
            //set intensity

            return _isOn;
        }
    }
}
