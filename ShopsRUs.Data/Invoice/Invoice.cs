
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Products;
using ShopsRUs.Data.Interfaces;

namespace ShopsRUs.Data.Invoice
{
    [System.Serializable]
    public class Invoice : IInvoice
    {
        public string UserName { get; set; }
        public List<Product> Products { get; set; }
        public Price TotalDiscount { get; set; }
        public Price TotalAmount { get; set; }
        public Price NetPrice { get; set; }
    }
}