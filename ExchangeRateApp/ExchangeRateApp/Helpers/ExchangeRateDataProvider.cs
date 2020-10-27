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
    public class ExchangeRateDataProvider
    {
        private const string _url = "https://www.nbp.pl/kursy/xml/lasta.xml";

        public CurrencyTable DeserializeXml()
        {
            var dataFromXml = GetXmlData();
            using (XmlReader reader = XmlReader.Create((new StringReader(dataFromXml.OuterXml))))
            {
                var serializer = new XmlSerializer(typeof(CurrencyTable));
                var deserializedData = (CurrencyTable)serializer.Deserialize(reader);

                return deserializedData;
            }
        }

        private XmlDocument GetXmlData()
        {
            XmlDocument data = new XmlDocument();
            data.Load(_url);
            var dataConverted = data.InnerXml.ToString().Replace(',', '.');
            data.LoadXml(dataConverted);
            return data;
        }
    }
}
