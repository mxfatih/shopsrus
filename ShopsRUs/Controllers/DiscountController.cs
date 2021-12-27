
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Data.Common;
using ShopsRUs.Data.Discount;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.Invoice;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBillService _billService;
        private readonly IDiscountService _discountService;
        private readonly IInvoiceService _invoiceService;

        public DiscountController(IBillService billService, IDiscountService discountService, IInvoiceService invoiceService, IUserService userService)
        {
            _billService = billService;
            _discountService = discountService;
            _invoiceService = invoiceService;
            _userService = userService;
        }

        [HttpGet]
        [Route("GetBillDiscount")]
        public async Task<Price> GetBillDiscount(int? billId, Currency currency)
        {
            if (billId == null)
            {
                return new Price { };
            }

            Data.Bill.Bill bill = await _billService.GetById(billId.Value);
            if (bill == null)
            {
                return new Price { };
            }

            Data.User.User user = await _userService.GetById(bill.UserId);
            if (user == null)
            {
                return new Price { };
            }

            return _discountService.CalculateTotalDiscount(user, bill, currency);
        }

        [HttpGet]
        [Route("GetInvoice")]
        public async Task<Invoice> GetInvoice(int? billId, Currency currency)
        {
            if (billId == null)
            {
                return null;
            }

            Data.Bill.Bill bill = await _billService.GetById(billId.Value);
            if (bill == null)
            {
                return null;
            }

            Data.User.User user = await _userService.GetById(bill.UserId);
            if (user == null)
            {
                return null;
            }

            return _invoiceService.GetInvoice(user, bill, currency);
        }
    }
}