
namespace ShopsRUs.Data.Interfaces
{
    public interface IDiscountable
    {
        public decimal GetDiscountAmount();
        public decimal GetDiscountPercentage();
    }
}