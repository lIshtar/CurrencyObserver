using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrencyObserver.Infrastructure.XmlModels
{
    public class ValuteXml
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }

        [XmlElement("Value")]
        public string ValueString
        {
            get => Value.ToString(CultureInfo.InvariantCulture).Replace('.', ',');
            set => Value = decimal.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        [XmlIgnore]
        public decimal Value { get; set; }

        [XmlElement("VunitRate")]
        public string VunitRateString
        {
            get => VunitRate.ToString(CultureInfo.InvariantCulture).Replace('.', ',');
            set => VunitRate = decimal.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        [XmlIgnore]
        public decimal VunitRate { get; set; }
    }
}
