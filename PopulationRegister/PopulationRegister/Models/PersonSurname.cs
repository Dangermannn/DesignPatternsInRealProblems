using PopulationRegister.Iterators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PopulationRegister.Models
{
    public class PersonSurname : IEnumerable
    {
        public string Surname { get; set; }
        public List<PersonPesel> Pesels { get; set; } = new List<PersonPesel>();
        public PersonSurname(){}
        public PersonSurname(string surname) => Surname = surname;

        public PersonSurname(string surname, string pesel)
        {
            Surname = surname;
            Pesels.Add(new PersonPesel(pesel));
        }

        public void AddPesel(string pesel)
        {
            var enumerator = GetEnumerator();
            var personPesel = new PersonPesel(pesel);
            while(enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonPesel).Pesel == pesel)
                {
                    Console.WriteLine("\nPESEL already exists!");
                    return;
                }
            }
            Pesels.Add(new PersonPesel(pesel));
        }

        public void RemovePesel(string pesel)
        {
            var enumerator = GetEnumerator();
            var personPesel = new PersonPesel(pesel);
            while (enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonPesel).Pesel == pesel)
                {
                    Pesels.Remove(enumerator.Current as PersonPesel);
                    Console.WriteLine("\nPESEL has been removed!");
                    return;
                }
            }
        }

        public void GetPesel(string pesel)
        {
            var enumerator = GetEnumerator();
            var personPesel = new PersonPesel(pesel);
            while (enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonPesel).Pesel == pesel)
                    Console.WriteLine("\tPESEL: " + (enumerator.Current as PersonPesel).Pesel);
            }
        }

        public void PrintAllPesels()
        {
            var enumerator = GetEnumerator();
            Console.Write("\tPESELS: ");
            while (enumerator.MoveNext())
                Console.Write("    " + (enumerator.Current as PersonPesel).Pesel);
            Console.WriteLine();
        }
        public IEnumerator GetEnumerator() => new PeopleIterator<PersonPesel>(Pesels);
    }
}
