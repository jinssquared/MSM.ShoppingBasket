using MSM.ShoppingBasket.API.Entities;
using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Interfaces
{
    public interface IProcessBasketService
    {
        ICollection<Product> CreateBasket(ICollection<string> basketItems, ICollection<Product> productList);

        decimal CalculatePreDiscountTotal(ICollection<Product> basket);
    }
}
