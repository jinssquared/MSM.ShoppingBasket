using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Interfaces;
using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Services
{
    public abstract class PackageDiscountService : IPackageDiscountService
    {
        public PackageDiscountService _next { get; set; }

        public abstract void applyPackageDiscount(ICollection<Product> shoppingBasket, List<decimal> totalDiscount);
    }
}
