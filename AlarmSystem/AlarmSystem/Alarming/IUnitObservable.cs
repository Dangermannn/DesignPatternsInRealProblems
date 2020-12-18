using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming
{
    public interface IUnitObservable
    {
        void Attach(IVFDUnit observer);
        void Detach(IVFDUnit observer);
        void Update(string CCIR_CODE);
    }
}
