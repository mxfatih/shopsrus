
using ShopsRUs.Data.Common;

namespace ShopsRUs.Data.Interfaces
{
    public interface IDiscount
    {
        public decimal CalculateDiscount(IUserDiscountable user, IBill bill, Currency currency = Currency.TRY);
    }
}