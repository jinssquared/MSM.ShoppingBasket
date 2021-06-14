using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Interfaces
{
    public interface IShopService
    {
        decimal CheckOut(ICollection<string> basket);
    }
}
