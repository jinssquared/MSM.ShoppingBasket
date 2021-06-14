using MSM.ShoppingBasket.API.Entities;
using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Interfaces
{
    public interface IPackageDiscountProcessor
    {
        void Create(List<PackageDiscount> discountItems);

        decimal applyPackageDiscount(ICollection<Product> basket);
    }
}
