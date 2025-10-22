using CurrencyObserver.Core.Interfaces;
using CurrencyObserver.Core.Services;
using CurrencyObserver.Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CurrencyObserver
{
    internal class Program
    {
        static async Task Main()
        {
            // Register encoding provider for CB XML (Windows-1251)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<IExchangeRateClient, CbCurrencyClient>();
                    services.AddTransient<ICurrencyAnalizer, CurrencyAnalizer>();
                    services.AddTransient<ICurrencyService, CurrencyService>();

                })
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Warning);
                })
                .Build();

            var services = host.Services.CreateScope().ServiceProvider;

            var currencyService = services.GetRequiredService<ICurrencyService>();
            var analyzer = services.GetRequiredService<ICurrencyAnalizer>();

            DateTime endDate = DateTime.Today;
            DateTime startDate = endDate.AddDays(-90);

            try
            {
                Console.WriteLine("Processing...");

                var rates = await currencyService.GetRatesForPeriodAsync(startDate, endDate);
                var maxRate = analyzer.GetMaxRate(rates);
                var minRate = analyzer.GetMinRate(rates);
                var averageRates = analyzer.GetAverageRate(rates);

                Console.WriteLine($"Max: {maxRate.Name} = {maxRate.VunitRate} ({maxRate.Date:dd.MM.yyyy})");
                Console.WriteLine($"Min: {minRate.Name} = {minRate.VunitRate} ({minRate.Date:dd.MM.yyyy})");

                Console.WriteLine("\nAverages:");

                averageRates.ToList().ForEach(r => Console.WriteLine($"{r.Name} : {r.VunitRate:F4}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
