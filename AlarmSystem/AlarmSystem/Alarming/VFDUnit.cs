using AlarmSystem.Alarming.Siren;
using AlarmSystem.Firefighters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming
{
    public class VFDUnit : IVFDUnit
    {
        public string UnitName { get; set; }
        public string TestCode { get; set; }
        public string AlarmCode { get; set; }

        private FirefightersContainer _firefighters = new FirefightersContainer();


        private SirenSimulation _siren = new SirenSimulation(false);
        private State.State _state;


        public VFDUnit(string unitName, string testCode, string alarmCode)  
        {
            UnitName = unitName;
            TestCode = testCode;
            AlarmCode = alarmCode;
            _state = new State.IdleState(this);
        }
        public void StartSirenSimulation() => _siren.SimulateSiren();

        public void Change(State.State state)
        {
            _state = state;
            _state.Change(this);
        }

        public void HandleState(string CCIR_CODE) => _state.Handle(CCIR_CODE);

        public void SwitchSirenStatus() => _siren.ChangeSirenStatus();

        public bool SirenIsOn() => _siren.IsOn();

        public ResponseCode Notify(string CCIR_CODE)
        {
            Console.WriteLine($"Unit { UnitName } received a notification.");
            _firefighters.Update();
            var code = _state.Handle(CCIR_CODE);
            if (code == ResponseCode.ERROR)
                Console.WriteLine("Error occured while notifyng a unit");
            else 
                Console.WriteLine("Unit has been notified successfully");
            return code;
        }

        public void AddFirefighter(IFirefighter firefighter) => _firefighters.Attach(firefighter);

    }
}
