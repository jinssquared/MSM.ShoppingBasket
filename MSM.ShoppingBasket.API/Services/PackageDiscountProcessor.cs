using MSM.ShoppingBasket.API.Entities;
using MSM.ShoppingBasket.API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MSM.ShoppingBasket.API.Services
{
    public class PackageDiscountProcessor : IPackageDiscountProcessor
    {
        private readonly IPackageDiscountServiceFactory _packageDiscountServiceFactory;

        private PackageDiscountService firstService;

        private PackageDiscountService lastService = null;

        public PackageDiscountProcessor(IPackageDiscountServiceFactory packageDiscountServiceFactory)
        {
            _packageDiscountServiceFactory = packageDiscountServiceFactory;
        }

        public void Create(List<PackageDiscount> discountItems)
        {
            foreach(var item in discountItems)
            {
                var discountService = _packageDiscountServiceFactory.Create(item);

                if (firstService == null)
                {
                    firstService = discountService;
                }
                else
                {
                    lastService._next = discountService;
                }

                lastService = discountService;
            }
        }

        public decimal applyPackageDiscount(ICollection<Product> basket)
        {
            List<decimal> totalDiscount = new List<decimal>();
            if (firstService != null)
            {
                firstService.applyPackageDiscount(basket, totalDiscount);
            }
            return totalDiscount.Sum(x => x);
        }
    }
}
