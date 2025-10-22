using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Interfaces
{
    public interface IExchangeRateClient
    {
        Task<ValCursXml> FetchDailyRatesAsync(DateTime date);
    }
}
