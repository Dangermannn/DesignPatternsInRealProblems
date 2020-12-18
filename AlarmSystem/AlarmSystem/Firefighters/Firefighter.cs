using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmSystem.Firefighters
{
    public class Firefighter : IFirefighter
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Firefighter(string name, string surname, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public void SendSms(string content) => Console.WriteLine($"Sending sms to { Name } { Surname } :  { content }");
    }
}
