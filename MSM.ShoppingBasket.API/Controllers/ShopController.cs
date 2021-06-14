using Microsoft.AspNetCore.Mvc;
using MSM.ShoppingBasket.API.Interfaces;
using System.Collections.Generic;

namespace MSM.ShoppingBasket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public decimal Post(ICollection<string> basket)
        {
            return _shopService.CheckOut(basket);
        }
    }
}
