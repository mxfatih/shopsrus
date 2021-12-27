
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.Invoice;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDiscountService _discountService;

        public InvoiceService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public Invoice GetInvoice<T>(T user, IBill bill, IList<IDiscount> discounts, Currency currency) where T : IUserDiscountable
        {
            Price totalDiscount = _discountService.CalculateTotalDiscount(user, bill, discounts, currency);
            Price totalAmount = bill.GetTotalPrice(currency);

            Invoice invoice = new Invoice
            {
                UserName = $"{user.Name} {user.SurName}",
                Products = bill.GetProducts(),
                TotalDiscount = totalDiscount,
                TotalAmount = totalAmount,
                NetPrice = new Price
                {
                    Currency = currency,
                    Value = totalAmount.Value - totalDiscount.Value
                },
            };

            return invoice;
        }
    }
}