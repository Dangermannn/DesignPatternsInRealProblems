using AlarmSystem.Alarming;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Firefighters
{
    public class FirefightersContainer : IFirefighterObservable
    {
        private List<IFirefighter> _firefighters = new List<IFirefighter>();

        public void Attach(IFirefighter observer) => _firefighters.Add(observer);

        public void Detach(IFirefighter observer) => _firefighters.Remove(observer);

        public void Update()
        {
            foreach (var f in _firefighters)
                f.SendSms("Fire!!!");
        }
    }
}
