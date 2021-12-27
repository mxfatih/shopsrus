
using System.Collections.Generic;
using System.Threading.Tasks;

using ShopsRUs.Data.Bill;
using ShopsRUs.Data.Common;
using ShopsRUs.Data.Products;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class BillService : IBillService
    {
        public async Task<Bill> GetById(int billId)
        {
            return billId switch
            {
                1 => new Bill
                {
                    Id = billId,
                    UserId = 1,
                    Products = new List<Product>
                    {
                        new Product{ Name = "Product1", Price = new Price { Currency = Currency.Dollar, Value = 100 }, ProductType = ProductType.Clothing },
                        new Product{ Name = "Product2", Price = new Price { Currency = Currency.Dollar, Value = 150 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product3", Price = new Price { Currency = Currency.Dollar, Value = 80 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product4", Price = new Price { Currency = Currency.Dollar, Value = 90 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product5", Price = new Price { Currency = Currency.Dollar, Value = 50 }, ProductType = ProductType.Clothing  },
                        new Product{ Name = "Product6", Price = new Price { Currency = Currency.Dollar, Value = 60 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product7", Price = new Price { Currency = Currency.Dollar, Value = 70 }, ProductType = ProductType.Clothing }
                    }
                },
                2 => new Bill
                {
                    Id = billId,
                    UserId = 2,
                    Products = new List<Product>
                    {
                        new Product{ Name = "Product1", Price = new Price { Currency = Currency.Dollar, Value = 200 }, ProductType = ProductType.Clothing },
                        new Product{ Name = "Product2", Price = new Price { Currency = Currency.Dollar, Value = 300 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product3", Price = new Price { Currency = Currency.Dollar, Value = 160 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product4", Price = new Price { Currency = Currency.Dollar, Value = 180 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product5", Price = new Price { Currency = Currency.Dollar, Value = 100 }, ProductType = ProductType.Clothing  },
                        new Product{ Name = "Product6", Price = new Price { Currency = Currency.Dollar, Value = 120 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product7", Price = new Price { Currency = Currency.Dollar, Value = 140 }, ProductType = ProductType.Clothing }
                    }
                },
                3 => new Bill
                {
                    Id = billId,
                    UserId = 3,
                    Products = new List<Product>
                    {
                        new Product{ Name = "Product1", Price = new Price { Currency = Currency.Dollar, Value = 300 }, ProductType = ProductType.Clothing },
                        new Product{ Name = "Product2", Price = new Price { Currency = Currency.Dollar, Value = 450 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product3", Price = new Price { Currency = Currency.Dollar, Value = 240 }, ProductType = ProductType.Electronic },
                        new Product{ Name = "Product4", Price = new Price { Currency = Currency.Dollar, Value = 270 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product5", Price = new Price { Currency = Currency.Dollar, Value = 150 }, ProductType = ProductType.Clothing  },
                        new Product{ Name = "Product6", Price = new Price { Currency = Currency.Dollar, Value = 180 }, ProductType = ProductType.Grocery },
                        new Product{ Name = "Product7", Price = new Price { Currency = Currency.Dollar, Value = 210 }, ProductType = ProductType.Clothing }
                    }
                },
                _ => null
            };
        }
    }
}