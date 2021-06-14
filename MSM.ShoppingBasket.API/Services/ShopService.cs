using Microsoft.Extensions.Configuration;
using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MSM.ShoppingBasket.API.Services
{
    public class ShopService : IShopService
    {
        private readonly IConfiguration _configuration;

        private readonly IProcessBasketService _processBasketService;

        private readonly IPackageDiscountProcessor _packageDiscountProcessor;

        protected readonly List<Product> ProductList;

        protected readonly List<PackageDiscount> PackageDiscountList;


        public ShopService(IConfiguration configuration,
            IProcessBasketService processBasketService, 
            IPackageDiscountProcessor packageDiscountProcessor)
        {
            _configuration = configuration;
            _processBasketService = processBasketService;
            _packageDiscountProcessor = packageDiscountProcessor;


            ProductList = _configuration.GetSection("ProductList").Get<ICollection<Product>>().ToList();
            PackageDiscountList = _configuration.GetSection("PackageDiscounts").Get<ICollection<PackageDiscount>>().ToList();
            _packageDiscountProcessor.Create(PackageDiscountList);
        }

        public decimal CheckOut(ICollection<string> basketItems)
        {
            var shoppingBasket = _processBasketService.CreateBasket(basketItems, ProductList);

            var preDiscountTotal = _processBasketService.CalculatePreDiscountTotal(shoppingBasket);

            var discountAmount = _packageDiscountProcessor.applyPackageDiscount(shoppingBasket);

            return preDiscountTotal - discountAmount;
        }
    }
}
