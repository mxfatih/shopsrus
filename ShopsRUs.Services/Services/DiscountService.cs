
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class DiscountService : IDiscountService
    {
        public Price CalculateTotalDiscount<T>(T user, IBill bill, IList<IDiscount> discounts, Currency currency = Currency.TRY) where T : IUserDiscountable
        {
            decimal totalDiscount = 0;

            foreach (IDiscount discount in discounts)
            {
                totalDiscount += discount.CalculateDiscount(user, bill, currency);
            }

            return new Price { Currency = currency, Value = totalDiscount };
        }
    }
}