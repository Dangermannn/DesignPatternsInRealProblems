using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming.State
{
    public abstract class State
    {
        protected VFDUnit _unit;

        protected State(VFDUnit unit) => _unit = unit;

        public void Change(VFDUnit unit) => _unit = unit;
        public abstract ResponseCode Handle(string CCIR_CODE);
    }
}
