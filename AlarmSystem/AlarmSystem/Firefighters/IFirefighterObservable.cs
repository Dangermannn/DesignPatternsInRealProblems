using AlarmSystem.Firefighters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming
{
    public interface IFirefighterObservable
    {
        void Attach(IFirefighter observer);
        void Detach(IFirefighter observer);
        void Update();
    }
}

    