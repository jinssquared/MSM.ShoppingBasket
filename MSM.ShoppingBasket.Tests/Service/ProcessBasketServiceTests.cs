using System.Collections.Generic;
using System.Linq;
using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Services;
using NUnit.Framework;

namespace MSM.ShoppingBasket.Tests.Service
{
    [TestFixture]
    public class ProcessBasketServiceTests
    {
        private readonly List<Product> fakeBasket = new List<Product> { StaticTestData.TestProducts[0], StaticTestData.TestProducts[0], StaticTestData.TestProducts[1] };

        [Test]
        public void CreateBasket_returns_products_from_string()
        {
            var processBaskedService = new ProcessBasketService();
            var result =processBaskedService.CreateBasket(fakeBasket.Select(x => x.Name).ToList(), StaticTestData.TestProducts);


            Assert.AreEqual(fakeBasket, result);
        }

        [Test]
        public void CalculatePreDiscountTotal_returns_product_total_summed()
        {
            var expectedResult = fakeBasket.Sum(x => x.Price);

            var processBaskedService = new ProcessBasketService();
            var result = processBaskedService.CalculatePreDiscountTotal(fakeBasket);


            Assert.AreEqual(expectedResult, result);
        }
    }
}
