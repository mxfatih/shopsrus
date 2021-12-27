
using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.Invoice;

namespace ShopsRUs.Services.Interfaces
{
    public interface IInvoiceService
    {
        public Invoice GetInvoice<T>(T user, IBill bill, Currency currency = Currency.TRY) where T : IUserDiscountable;
    }
}