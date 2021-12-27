
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
        public async Task<Price> GetBillDiscount(int? userId, int? billId, Currency currency)
        {
            if (userId == null || billId == null)
            {
                return new Price { };
            }

            Data.User.User user = await _userService.GetById(userId.Value);
            if (user == null)
            {
                return new Price { };
            }

            Data.Bill.Bill bill = await _billService.GetById(billId.Value);
            if (bill == null)
            {
                return new Price { };
            }

            IList<IDiscount> discountsToApply = new List<IDiscount>
            {
                new DiscountAmount(),
                new DiscountUser()
            };

            return _discountService.CalculateTotalDiscount(user, bill, discountsToApply, currency);
        }

        [HttpGet]
        [Route("GetInvoice")]
        public async Task<Invoice> GetInvoice(int? userId, int? billId, Currency currency)
        {
            if (userId == null || billId == null)
            {
                return null;
            }

            Data.User.User user = await _userService.GetById(userId.Value);
            if (user == null)
            {
                return null;
            }

            Data.Bill.Bill bill = await _billService.GetById(billId.Value);
            if (bill == null)
            {
                return null;
            }

            IList<IDiscount> discountsToApply = new List<IDiscount>
            {
                new DiscountAmount(),
                new DiscountUser()
            };

            return _invoiceService.GetInvoice(user, bill, discountsToApply, currency);
        }
    }
}