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
        Task<ValCursXml> GetDailyRatesAsync(DateTime date);
        Task<List<ValCursXml>> GetRatesForPeriodAsync(DateTime start, DateTime end);
    }
}
