using PopulationRegister.Iterators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PopulationRegister.Models
{
    public class PersonName : IEnumerable
    {
        public string Name { get; set; }
        public List<PersonSurname> Surnames = new List<PersonSurname>();
        public PersonName(){}

        public PersonName(string name) => Name = name;

        public PersonName(string name, string surname)
        {
            Name = name;
            Surnames.Add(new PersonSurname(surname));
        }

        public PersonName(string name, string surname, string pesel)
        {
            Name = name;
            Surnames.Add(new PersonSurname(surname, pesel));
        }

        public void AddSurname(string surname, string pesel = null)
        {
            var enumerator = GetEnumerator();
            var personSurname = new PersonSurname(surname);
            while (enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonSurname).Surname == surname)
                {
                    if(pesel == null)
                    {
                        Console.WriteLine("\nSurname already exists!");
                        //(enumerator.Current as PersonSurname).AddPesel(pesel);
                        return;
                    }
                    (enumerator.Current as PersonSurname).AddPesel(pesel);
                }
            }
            if(pesel != null) 
            {
                //Surnames.Add(new PersonSurname(surname, pesel));
                personSurname.AddPesel(pesel);
                Surnames.Add(personSurname);
                return;
            }
            Surnames.Add(new PersonSurname(surname));
        }

        public void RemoveSurname(string surname, string pesel = null)
        {
            var enumerator = GetEnumerator();
            var personSurname = new PersonSurname(surname);
            while (enumerator.MoveNext())
            {
                if(pesel == null)
                    if ((enumerator.Current as PersonSurname).Surname == surname)
                    {
                        Surnames.Remove(enumerator.Current as PersonSurname);
                        Console.WriteLine("\nSurname has been removed!");
                        return;
                    }
                
                if(pesel != null)
                    if ((enumerator.Current as PersonSurname).Surname == surname)
                    { 
                        (enumerator.Current as PersonSurname).RemovePesel(pesel);
                        return;
                    }
            }
        }

        public void GetSurname(string surname, string pesel = null)
        {
            var enumerator = GetEnumerator();
            var personSurname = new PersonSurname(surname);
            while (enumerator.MoveNext())
            {
                if ((enumerator.Current as PersonSurname).Surname == surname)
                {
                    Console.Write("\tSurname: " + (enumerator.Current as PersonSurname).Surname);
                    if (pesel != null)
                    {
                        (enumerator.Current as PersonSurname).GetPesel(pesel);
                        return;
                    }
                    (enumerator.Current as PersonSurname).PrintAllPesels();
                    return;
                }           
            }
            Console.WriteLine("\nThere's no person with that surname");
        }

        public void PrintAllSurnames()
        {
            var enumerator = GetEnumerator();
            Console.Write("Surnames: ");
            while(enumerator.MoveNext())
                Console.Write((enumerator.Current as PersonSurname).Surname + "    ");
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator() => new PeopleIterator<PersonSurname>(Surnames);
    }
}
