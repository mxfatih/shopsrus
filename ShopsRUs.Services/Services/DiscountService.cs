
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Discount;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class DiscountService : IDiscountService
    {
        /// <summary>
        /// Calculates TotalDiscount according to the given Bill & User
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="bill"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price CalculateTotalDiscount<T>(T user, IBill bill, Currency currency = Currency.TRY) where T : IUserDiscountable
        {
            IList<IDiscount> discounts = this.GetDiscounts(user, bill);

            decimal totalDiscount = 0;

            foreach (IDiscount discount in discounts)
            {
                totalDiscount += discount.CalculateDiscount(user, bill, currency);
            }

            return new Price { Currency = currency, Value = totalDiscount };
        }

        /// <summary>
        /// Finds Discount according to the given Bill & User
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="bill"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<IDiscount> GetDiscounts<T>(T user, IBill bill) where T : IUserDiscountable
        {
            IList<IDiscount> discounts = new List<IDiscount>
            {
                new DiscountAmount(),
                new DiscountUser()
            };

            return discounts;
        }
    }
}