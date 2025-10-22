using CurrencyObserver.Core.Interfaces;
using CurrencyObserver.Core.Models;
using CurrencyObserver.Infrastructure.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Services
{
    public class CurrencyAnalizer : ICurrencyAnalizer
    {
        public IEnumerable<CurrencyRateRecord> GetAverageRate(List<ValuteCursXml> rates)
        {
            // Extract all currency values from the provided rates
            // Then cast them to "decimal" from "decimal?"
            // ("decimal?" does not support Average() directly)
            var valutes = rates.SelectMany(r => r.Valutes.Select(
                v => new CurrencyRateRecord
                {
                    CharCode = v.CharCode,
                    Name = v.Name,
                    VunitRate = v.VunitRate,
                    Date = r.Date
                })); ;

            var averages = valutes
                .GroupBy(v => v.CharCode)
                .Select(g => new CurrencyRateRecord
                {
                    CharCode = g.Key,
                    Name = g.First().Name,
                    VunitRate = g.Average(v => v.VunitRate)
                });

            return averages;
        }

        // I could avoid repeating the code, but then the solution wouldn’t look very good, so I’ll leave it as is.
        public CurrencyRateRecord GetMaxRate(List<ValuteCursXml> rates)
        {
            // I want to override operators so badly
            // Unfortunately it is not good solution for this system

            if (rates == null || rates.Count == 0)
                throw new ArgumentException("No data available for currency analysis.", nameof(rates));

            var valutes = rates.SelectMany(r => r.Valutes.Select(
                v => new CurrencyRateRecord
                {
                    CharCode = v.CharCode,
                    Name = v.Name,
                    VunitRate = v.VunitRate,
                    Date = r.Date
                }));

            return valutes.MaxBy(v => v.VunitRate) ?? 
                throw new InvalidOperationException("Failed to determine the maximum — the collection is empty.");
        }

        public CurrencyRateRecord GetMinRate(List<ValuteCursXml> rates)
        {
            if (rates == null || rates.Count == 0)
                throw new ArgumentException("No data available for currency analysis.", nameof(rates));

            var valutes = rates.SelectMany(r => r.Valutes.Select(
                v => new CurrencyRateRecord
                {
                    CharCode = v.CharCode,
                    Name = v.Name,
                    VunitRate = v.VunitRate,
                    Date = r.Date
                }));

            return valutes.MinBy(v => v.VunitRate) ??
                throw new InvalidOperationException("Failed to determine the maximum — the collection is empty.");
        }
    }
}
