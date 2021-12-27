
using System.Collections.Generic;

namespace ShopsRUs.Data.Common
{
    [System.Serializable]
    public enum Currency : int
    {
        TRY = 1,
        Dollar,
        Euro
    }

    public static class CurrencyExtensions
    {
        private static readonly Dictionary<Currency, decimal> CurrencyRates = new Dictionary<Currency, decimal>
        {
            { Currency.TRY, 1M },
            { Currency.Dollar, 6M },
            { Currency.Euro, 7.5M },
        };

        public static decimal GetTargetCurrencyRate(this Currency? baseCurrency, Currency? targetCurrency)
        {
            if (baseCurrency == null)
            {
                throw new System.ArgumentNullException(nameof(baseCurrency), "Please be sure for Base currency!");
            }

            if (targetCurrency == null)
            {
                throw new System.ArgumentNullException(nameof(targetCurrency), "Please be sure for Target currency!");
            }

            if (!CurrencyRates.ContainsKey(baseCurrency.Value))
            {
                throw new System.Exception("Couldn't find base currency!");
            }

            if (!CurrencyRates.ContainsKey(targetCurrency.Value))
            {
                throw new System.Exception("Couldn't find target currency!");
            }

            decimal baseRate = CurrencyRates[baseCurrency.Value];

            if (baseCurrency == targetCurrency)
            {
                return baseRate;
            }

            decimal targetRate = CurrencyRates[targetCurrency.Value];

            return baseRate / targetRate;
        }
    }
}