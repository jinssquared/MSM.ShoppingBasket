using MSM.ShoppingBasket.API.Entities;
using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Interfaces
{
    public interface IPackageDiscountService
    {
        void applyPackageDiscount(ICollection<Product> shoppingBasket, List<decimal> totalDiscount);
    }
}
