using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming.State
{
    public class AlarmState : State
    {
        public AlarmState(VFDUnit unit) : base(unit) { }
        public override ResponseCode Handle(string CCIR_CODE)
        {
            _unit.Change(this);
            if (!_unit.SirenIsOn())
                _unit.SwitchSirenStatus();
            if (_unit.SirenIsOn())
                return ResponseCode.ALARM_OK;
            return ResponseCode.ERROR;
        }
    }
}
