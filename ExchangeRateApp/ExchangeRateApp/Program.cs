
using ExchangeRateApp.Controller;
using ExchangeRateApp.Data;
using ExchangeRateApp.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainApplication mainApp = new MainApplication(new ExchangeRateService(new ExchangeRateRepository()));
            mainApp.Run();
        }
    }
}
