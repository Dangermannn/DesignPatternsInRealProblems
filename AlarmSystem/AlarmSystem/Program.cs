using AlarmSystem.Alarming;
using AlarmSystem.Firefighters;
using System;

namespace AlarmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading units...");
            VFDUnit u1 = new VFDUnit("best1", "1111", "1112");
            VFDUnit u2 = new VFDUnit("best2", "2222", "2223");
            VFDUnit u3 = new VFDUnit("best3", "3333", "3334");

            Console.WriteLine("Loading firefighters...");
            u1.AddFirefighter(new Firefighter("robert", "styczen", "111111111"));
            u1.AddFirefighter(new Firefighter("andrzej", "niemiec", "111132231"));
            u1.AddFirefighter(new Firefighter("john", "smith", "111151111"));
            u2.AddFirefighter(new Firefighter("kornel", "luty", "111611111"));
            u2.AddFirefighter(new Firefighter("pawel", "grudzien", "111181111"));
            u3.AddFirefighter(new Firefighter("krzychu", "maj", "119111111"));

            Console.WriteLine("Done\n\n");


            u1.Notify("1111");

            Console.WriteLine("Press key to end...");
            Console.ReadKey();
        }
    }
}
