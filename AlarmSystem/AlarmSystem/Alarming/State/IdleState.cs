using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming.State
{
    public class IdleState : State
    {
        public IdleState(VFDUnit unit) : base(unit) { }
        public override ResponseCode Handle(string CCIR_CODE)
        {
            if (_unit.TestCode == CCIR_CODE)
            {
                _unit.Change(new TestState(_unit));
                _unit.HandleState(CCIR_CODE);
                return ResponseCode.TEST_OK;
            }
            else if (_unit.AlarmCode == CCIR_CODE)
            {
                _unit.Change(new AlarmState(_unit));
                _unit.HandleState(CCIR_CODE);
                return ResponseCode.ALARM_OK;
            }

            if (_unit.SirenIsOn())
                _unit.SwitchSirenStatus();

            return ResponseCode.ERROR;
        }
    }
}
