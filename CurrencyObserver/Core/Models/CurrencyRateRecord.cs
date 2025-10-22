namespace CurrencyObserver.Core.Models
{
    public class CurrencyRateRecord
    {
        public string CharCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}