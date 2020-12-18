using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Alarming
{
    public class VFDUnitsContainer : IUnitObservable
    {
        private List<IVFDUnit> _units = new List<IVFDUnit>();
        public void Attach(IVFDUnit observer) => _units.Add(observer);

        public void Detach(IVFDUnit observer) => _units.Remove(observer);

        public void Update(string CCIR_CODE)
        {
            foreach(var item in _units)
            {
                var response = item.Notify(CCIR_CODE);
                if(response == ResponseCode.ERROR)
                    Console.WriteLine("Error occured while notfying unit!");
                Console.WriteLine("Unit has received the message successfully!");
            }
        }
    }
}
