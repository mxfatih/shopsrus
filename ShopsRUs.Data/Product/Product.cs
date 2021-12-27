using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;

namespace ShopsRUs.Data.Products
{
    [System.Serializable]
    public class Product : IProduct
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public Price Price { get; set; }
    }
}