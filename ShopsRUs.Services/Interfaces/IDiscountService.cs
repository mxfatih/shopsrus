
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;

namespace ShopsRUs.Services.Interfaces
{
    public interface IDiscountService
    {
        public Price CalculateTotalDiscount<T>(T userDiscountable, IBill bill, IList<IDiscount> discounts, Currency currency = Currency.TRY) where T : IUserDiscountable;
    }
}