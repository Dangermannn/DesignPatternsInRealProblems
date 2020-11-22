using System;
using System.Collections.Generic;
using System.Text;

namespace PopulationRegister.Models
{
    public class PersonPesel
    {
        public string Pesel { get; set; }

        public PersonPesel(){}

        public PersonPesel(string pesel) => Pesel = pesel;
    }
}
