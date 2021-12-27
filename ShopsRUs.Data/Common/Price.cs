
namespace ShopsRUs.Data.Common
{
    public struct Price
    {
        public decimal Value { get; set; }
        public Currency? Currency { get; set; }
    }

    public static class PriceHelper
    {
        public static Price ToDifferentCurrency(this Price price, Currency? targetCurrency)
        {
            decimal rate = price.Currency.GetTargetCurrencyRate(targetCurrency);

            return new Price
            {
                Currency = targetCurrency.Value,
                Value = price.Value * rate
            };
        }
    }
}