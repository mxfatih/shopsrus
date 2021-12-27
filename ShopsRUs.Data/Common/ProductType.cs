
namespace ShopsRUs.Data.Common
{
    [System.Serializable]
    public enum ProductType : int
    {
        Clothing = 1,
        Electronic,
        Grocery
    }

    public static class ProductTypeExtensions
    {
        public static string ToCurrencyLabel(this Currency currency)
        {
            switch (currency)
            {
                case Currency.Dollar:
                    return "$";
                case Currency.Euro:
                    return "€";
                case Currency.TRY:
                default:
                    return "TL";
            }
        }
    }
}