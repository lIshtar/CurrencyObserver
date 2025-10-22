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
        CurrencyRateRecord GetMaxRate(List<ValCursXml> rates);
        CurrencyRateRecord GetMinRate(List<ValCursXml> rates);
        decimal GetAverageRate(List<ValCursXml> rates);
    }
}
