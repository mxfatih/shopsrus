
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;

namespace ShopsRUs.Services.Interfaces
{
    public interface IDiscountService
    {
        /// <summary>
        /// Calculates TotalDiscount according to the given Bill & User
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="bill"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price CalculateTotalDiscount<T>(T user, IBill bill, Currency currency = Currency.TRY) where T : IUserDiscountable;

        /// <summary>
        /// Finds Discounts according to the given Bill & User
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="user"></param>
        /// <param name="bill"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<IDiscount> GetDiscounts<T>(T user, IBill bill) where T : IUserDiscountable;
    }
}