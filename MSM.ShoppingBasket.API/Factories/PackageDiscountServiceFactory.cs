using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Interfaces;
using MSM.ShoppingBasket.API.Services;

namespace MSM.ShoppingBasket.API.Factories
{
    public class PackageDiscountServiceFactory : IPackageDiscountServiceFactory
    {
        public PackageDiscountService Create(PackageDiscount packageDiscountItem)
        {
            return new BasicPackageDiscountService(packageDiscountItem);
        }
    }
}
