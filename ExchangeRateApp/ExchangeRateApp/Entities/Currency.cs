using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRateApp
{
    public class Currency
    {
        [XmlElement("nazwa_waluty")]
        public string CurrencyName { get; set; }

        private decimal _multiplier;

        [XmlElement(ElementName ="przelicznik")]
        public decimal Multiplier
        {
            get => _multiplier;
            set => _multiplier = Decimal.Parse(value.ToString()); 
        }

        [XmlElement("kod_waluty")]
        public string CurrencyCode { get; set; }

        private decimal _averageMultiplier;

        [XmlElement(ElementName = "kurs_sredni")]
        public decimal AverageMultiplier 
        {
            get => _averageMultiplier;
            set => _averageMultiplier = Decimal.Parse(value.ToString());
        }
    }
}
