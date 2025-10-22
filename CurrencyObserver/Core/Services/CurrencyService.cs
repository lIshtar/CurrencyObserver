using CurrencyObserver.Core.Interfaces;
using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IExchangeRateClient _client;

        public CurrencyService(IExchangeRateClient client)
        {
            _client = client;
        }

        public Task<ValCursXml> GetDailyRatesAsync(DateTime date)
        {
            return _client.FetchDailyRatesAsync(date);
        }

        public Task<List<ValCursXml>> GetRatesForPeriodAsync(DateTime start, DateTime end)
        {
            var tasks = new List<Task<ValCursXml>>();

            for (var date = start; date <= end; date = date.AddDays(1))
            {
                tasks.Add(_client.FetchDailyRatesAsync(date));
            }

            return Task.WhenAll(tasks)
                .ContinueWith(t => t.Result.ToList());
        }
    }
}
