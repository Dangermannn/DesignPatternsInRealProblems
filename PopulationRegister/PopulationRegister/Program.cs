using PopulationRegister.Models;
using System;
using System.Collections.Generic;

namespace PopulationRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleRegister register = new PeopleRegister();
            register.AddPerson("Robert", "Styczeń", "1");
            register.AddPerson("Robert", "Styczeń", "2");
            register.AddPerson("Robert", "Luty", "3");

            register.GetPerson("Robert");
            register.GetPerson("Robert", "Styczeń");

            register.RemovePerson("Robert", "Styczeń", "2");
            register.GetPerson("Robert", "Styczeń");
          
            Console.ReadKey();
        }

    }
}
