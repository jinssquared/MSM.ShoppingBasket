using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Services;

namespace MSM.ShoppingBasket.API.Interfaces
{
    public interface IPackageDiscountServiceFactory
    {
        PackageDiscountService Create(PackageDiscount packageDiscountItem);
    }
}
