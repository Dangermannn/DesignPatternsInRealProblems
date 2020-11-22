using PopulationRegister.Iterators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PopulationRegister.Models
{
    public class PeopleRegister : IEnumerable
    {
        public List<PersonName> People { get; set; }

        public PeopleRegister() => People = new List<PersonName>();

        public void AddPerson(string name, string surname = null, string pesel = null)
        {
            var enumerator = GetEnumerator();
            var personName = new PersonName(name);
            while (enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonName).Name == name)
                {
                    if(surname == null)
                    {
                        Console.WriteLine("\nPerson name already exists!");
                        return;
                    }

                    (enumerator.Current as PersonName).AddSurname(surname, pesel);
                }
            }

            if (surname != null)
            {
                personName.AddSurname(surname, pesel);
                //People.Add(new PersonName(name, surname, pesel)); 
                People.Add(personName);
            }
        }

        public void RemovePerson(string name, string surname = null, string pesel = null)
        {
            var enumerator = GetEnumerator();
            while(enumerator.MoveNext())
            {
                if((enumerator.Current as PersonName).Name == name)
                {
                    if (surname == null)
                        People.Remove(enumerator.Current as PersonName);
                    if (pesel == null)
                        (enumerator.Current as PersonName).RemoveSurname(surname);
                    (enumerator.Current as PersonName).RemoveSurname(surname, pesel);
                    return;
                }
            }

            Console.WriteLine("\nPerson has been removed!");
        }

        public void GetPerson(string name, string surname = null, string pesel = null)
        {
            var enumerator = GetEnumerator();
            while(enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonName).Name == name)
                {
                    Console.WriteLine("Name: " + (enumerator.Current as PersonName).Name);
                    if (surname != null)
                    {
                        (enumerator.Current as PersonName).GetSurname(surname, pesel);
                        return;
                    }
                    (enumerator.Current as PersonName).PrintAllSurnames();
                    return;
                }

            }
        }

        public IEnumerator GetEnumerator() => new PeopleIterator<PersonName>(People);
    }
}
