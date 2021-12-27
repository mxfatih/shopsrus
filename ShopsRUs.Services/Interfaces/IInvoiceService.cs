
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.Invoice;

namespace ShopsRUs.Services.Interfaces
{
    public interface IInvoiceService
    {
        public Invoice GetInvoice<T>(T user, IBill bill, IList<IDiscount> discounts, Currency currency = Currency.TRY) where T : IUserDiscountable;
    }
}