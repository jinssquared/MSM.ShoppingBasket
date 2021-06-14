using System.Collections.Generic;
using MSM.ShoppingBasket.API.Entities;

namespace MSM.ShoppingBasket.Tests.Service
{
    public static class StaticTestData
    {
        public static List<Product> TestProducts = new List<Product>
        {
           new Product {Name = "Butter", Price = 0.8m},
           new Product {Name = "Milk", Price = 1.15m},
           new Product {Name = "Bread", Price = 1m}
        };

        public static List<PackageDiscount> TestPackageDiscounts = new List<PackageDiscount>
        {
           new PackageDiscount {ProductName = "Butter", AmountNeededForDiscount = 2, DiscountedProductName = "Bread", DiscountAmount = .5m},
           new PackageDiscount {ProductName = "Milk", AmountNeededForDiscount = 4, DiscountedProductName = "Milk", DiscountAmount = 1.15m},
        };
    }
}
