
using System.Threading.Tasks;

using ShopsRUs.Data.Bill;
using ShopsRUs.Data.Common;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class BillService : IBillService
    {
        public async Task<Bill> GetById(int billId)
        {
            return new Bill
            {
                Id = billId,
                Products = new System.Collections.Generic.List<Data.Products.Product>
                {
                    new Data.Products.Product{ Name = "Product1", Price = new Price { Currency = Currency.Dollar, Value = 100 }, ProductType = ProductType.Clothing },
                    new Data.Products.Product{ Name = "Product2", Price = new Price { Currency = Currency.Dollar, Value = 150 }, ProductType = ProductType.Electronic },
                    new Data.Products.Product{ Name = "Product3", Price = new Price { Currency = Currency.Dollar, Value = 80 }, ProductType = ProductType.Electronic },
                    new Data.Products.Product{ Name = "Product4", Price = new Price { Currency = Currency.Dollar, Value = 90 }, ProductType = ProductType.Grocery },
                    new Data.Products.Product{ Name = "Product5", Price = new Price { Currency = Currency.Dollar, Value = 50 }, ProductType = ProductType.Clothing  },
                    new Data.Products.Product{ Name = "Product6", Price = new Price { Currency = Currency.Dollar, Value = 60 }, ProductType = ProductType.Grocery },
                    new Data.Products.Product{ Name = "Product7", Price = new Price { Currency = Currency.Dollar, Value = 70 }, ProductType = ProductType.Clothing }
                }
            };
        }
    }
}