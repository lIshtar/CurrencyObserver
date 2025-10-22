using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Infrastructure.Exceptions
{
    public class XmlDeserializationException(string message, string xmlContent = "") : Exception(message)
    {
        public string XmlContent { get; } = xmlContent;
    }
}
