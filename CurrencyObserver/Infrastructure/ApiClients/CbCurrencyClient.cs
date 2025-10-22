using CurrencyObserver.Core.Interfaces;
using CurrencyObserver.Infrastructure.Exceptions;
using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrencyObserver.Infrastructure.ApiClients
{
    public class CbCurrencyClient : IExchangeRateClient
    {
        private readonly HttpClient _httpClient;
        private readonly XmlSerializer _dailySerializer;
        private const string DailyRatesEndpoint = "https://www.cbr.ru/scripts/XML_daily.asp?date_req={0:dd/MM/yyyy}";
        public CbCurrencyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _dailySerializer = new XmlSerializer(typeof(ValuteCursXml));
        }

        public async Task<ValuteCursXml> FetchDailyRatesAsync(DateTime date)
        {
            var url = string.Format(DailyRatesEndpoint, date);

            using var response = await _httpClient.GetStreamAsync(url)
                ?? throw new HttpRequestException("Failed to get daily rates.");
            
            var valCurs = (ValuteCursXml?)_dailySerializer.Deserialize(response) 
                ?? throw new XmlDeserializationException("Failed to deserialize daily rates."); ;

            return valCurs;
        }
    }
}
