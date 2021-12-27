
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Products;

namespace ShopsRUs.Data.Interfaces
{
    public interface IBill
    {
        public List<Product> GetProducts();
        public Price GetTotalPrice(Currency? currency);
        public Price GetTotalPriceForSpecificProducts(Currency currency, List<ProductType> includedProductTypes = null, List<ProductType> excludedProductTypes = null);
    }
}