using MSM.ShoppingBasket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSM.ShoppingBasket.API.Services
{
    public class BasicPackageDiscountService : PackageDiscountService
    {
        private PackageDiscount PackageDiscountItem { get; set; }

        public BasicPackageDiscountService(PackageDiscount packageDiscountItem)
        {
            PackageDiscountItem = packageDiscountItem;
        }

        public override void applyPackageDiscount(ICollection<Product> shoppingBasket, List<decimal> totalDiscount)
        {
            var baseProductQuantity = shoppingBasket.Count(p => p.Name == PackageDiscountItem.ProductName);
            var discountedProductQuantity = shoppingBasket.Count(p => p.Name == PackageDiscountItem.DiscountedProductName);

            if (baseProductQuantity > 0 && 
                discountedProductQuantity > 0 && 
                baseProductQuantity >= PackageDiscountItem.AmountNeededForDiscount)
            {
                totalDiscount.Add(PackageDiscountItem.DiscountAmount * (decimal)Math.Ceiling((double)discountedProductQuantity / baseProductQuantity) );
            }

            if (_next != null)
            {
                _next.applyPackageDiscount(shoppingBasket, totalDiscount);
                return;
            }

            return;
        }
    }
}
