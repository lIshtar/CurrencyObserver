using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static CurrencyObserver.Program;

namespace CurrencyObserver.Infrastructure.XmlModels
{
    [XmlRoot("ValCurs")]
    public class ValuteCursXml
    {
        [XmlAttribute("Date")]
        public string DateRaw
        {
            get => Date.ToString("dd.MM.yyyy");
            set => Date = DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("Valute")]
        public List<ValuteXml> Valutes { get; set; }
    }
}
