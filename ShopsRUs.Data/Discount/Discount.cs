
using System;
using System.Collections.Generic;

using ShopsRUs.Data.Common;
using ShopsRUs.Data.Interfaces;
using ShopsRUs.Data.User;

namespace ShopsRUs.Data.Discount
{
    public abstract class Discount : IDiscount
    {
        public virtual DiscountType DiscountType { get; }

        public virtual decimal CalculateDiscount(IUserDiscountable user, IBill bill, Currency currency = Currency.TRY) => 0M;
    }

    public class DiscountUser : Discount
    {
        public override DiscountType DiscountType => DiscountType.Percentage;
        private List<ProductType> ExcludedProductTypes => new List<ProductType> { ProductType.Grocery };

        public override decimal CalculateDiscount(IUserDiscountable user, IBill bill, Currency currency = Currency.TRY)
        {
            List<Products.Product> products = bill.GetProducts();
            if (products?.Count == 0)
            {
                return 0M;
            }

            Price billTotal = bill.GetTotalPrice(currency);

            if (billTotal.Value == 0)
            {
                return 0M;
            }

            decimal discount = 0;

            //  User type Discount apply for "Non Grocery Products"
            decimal userDiscountPercentage = user.GetDiscountPercentage();
            if (userDiscountPercentage > 0)
            {
                Price billTotalForSpecificProducts = bill.GetTotalPriceForSpecificProducts(currency, excludedProductTypes: ExcludedProductTypes);
                
                if (billTotalForSpecificProducts.Value > 0)
                {
                    discount += billTotalForSpecificProducts.Value * userDiscountPercentage / 100;
                }
            }

            return discount;
        }
    }

    /// <summary>
    /// Discount apply for each 100$ of Bill total
    /// </summary>
    public class DiscountAmount : Discount
    {
        public override DiscountType DiscountType => DiscountType.Amount;

        private readonly Currency? ProcessCurrency = Currency.Dollar;

        public override decimal CalculateDiscount(IUserDiscountable user, IBill bill, Currency currency = Currency.TRY)
        {
            List<Products.Product> products = bill.GetProducts();
            if (products?.Count == 0)
            {
                return 0M;
            }

            Price billTotal = bill.GetTotalPrice(ProcessCurrency);

            if (billTotal.Value == 0)
            {
                return 0M;
            }

            decimal discount = 0;

            if (billTotal.Value > 100)
            {
                decimal hundredCycle = Math.Floor(billTotal.Value / 100);

                discount += hundredCycle * 5M;
            }

            if (ProcessCurrency != currency)
            {
                discount *= ProcessCurrency.GetTargetCurrencyRate(currency);
            }

            return discount;
        }
    }
}