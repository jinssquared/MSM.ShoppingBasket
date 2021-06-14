using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MSM.ShoppingBasket.API.Services
{
    public class ProcessBasketService : IProcessBasketService
    {
        public ICollection<Product> CreateBasket(ICollection<string> basketItems, ICollection<Product> productList)
        {
            List<Product> result = new List<Product>();
            foreach(var item in basketItems)
            {
                var product = productList.FirstOrDefault(pl => string.Equals(pl.Name, item));

                if(product != null)
                    result.Add(product);
            }

            return result;
        }

        public decimal CalculatePreDiscountTotal(ICollection<Product> basket)
        {
            return basket.Sum(x => x.Price);
        }
    }
}
