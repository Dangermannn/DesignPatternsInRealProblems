using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRateApp
{
    [XmlRoot("tabela_kursow")]
    public class CurrencyTable
    {
        [XmlElement("numer_tabeli")]
        public string TableNumber { get; set; }

        [XmlElement("data_publikacji")]
        public string PublicationDate { get; set; }

        [XmlElement("pozycja")]
        public List<Currency> CurrencyList { get; set; }
    }
}
