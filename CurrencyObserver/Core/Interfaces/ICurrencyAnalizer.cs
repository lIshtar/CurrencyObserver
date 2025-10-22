using CurrencyObserver.Core.Models;
using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Interfaces
{
    internal interface ICurrencyAnalizer
    {
        CurrencyRateRecord GetMaxRate(List<ValuteCursXml> rates);
        CurrencyRateRecord GetMinRate(List<ValuteCursXml> rates);
        decimal GetAverageRate(List<ValuteCursXml> rates);
    }
}
