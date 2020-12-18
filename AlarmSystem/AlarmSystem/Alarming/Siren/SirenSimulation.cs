using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlarmSystem.Alarming.Siren
{
    public class SirenSimulation
    {
        private bool _isOn;

        public SirenSimulation(bool isOn) => _isOn = isOn;

        public void SimulateSiren()
        {
            if(_isOn)
                Console.WriteLine("<<Siren sound>>");
        }
        public void ChangeSirenStatus()
        {
            _isOn = !_isOn;
            if (_isOn)
                 SimulateSiren();
        }

        public bool IsOn() => _isOn;
    }
}
