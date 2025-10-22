using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Interfaces
{
    public interface ICurrencyService
    {
        Task<ValuteCursXml> GetDailyRatesAsync(DateTime date);
        Task<List<ValuteCursXml>> GetRatesForPeriodAsync(DateTime start, DateTime end);
    }
}
