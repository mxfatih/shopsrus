
using System.Collections.Generic;

using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.Products;
using ShopsRUs.Data.Common;

namespace ShopsRUs.Data.Bill
{
    [System.Serializable]
    public class Bill : IBill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }

        public List<Product> GetProducts() => Products;

        public Price GetTotalPrice(Currency? currency)
        {
            decimal totalPrice = 0M;
            foreach (Product product in Products)
            {
                if (product.Price.Currency == currency)
                {
                    totalPrice += product.Price.Value;
                }
                else
                {
                    totalPrice += product.Price.ToDifferentCurrency(currency).Value;
                }
            }

            return new Price
            {
                Currency = currency,
                Value = totalPrice
            };

            ////  Short code
            //return new Price
            //{
            //    Currency = currency,
            //    Value = Products.Sum(x => product.Price.Currency == currency ? product.Price.Value : product.Price.ConvertPriceToDifferentExchange(currency).Value)
            //};
        }

        public Price GetTotalPriceForSpecificProducts(Currency currency, List<ProductType> includedProductTypes = null, List<ProductType> excludedProductTypes = null)
        {
            List<Product> specificProducts = new List<Product>(Products);

            if (includedProductTypes?.Count > 0)
            {
                specificProducts.RemoveAll(x => !includedProductTypes.Contains(x.ProductType));
            }

            if (excludedProductTypes?.Count > 0)
            {
                specificProducts.RemoveAll(x => excludedProductTypes.Contains(x.ProductType));
            }

            decimal totalPrice = 0M;
            foreach (Product product in specificProducts)
            {
                if (product.Price.Currency == currency)
                {
                    totalPrice += product.Price.Value;
                }
                else
                {
                    totalPrice += product.Price.ToDifferentCurrency(currency).Value;
                }
            }

            return new Price
            {
                Currency = currency,
                Value = totalPrice
            };
        }
    }
}