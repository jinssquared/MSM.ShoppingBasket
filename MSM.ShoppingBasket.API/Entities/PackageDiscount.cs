namespace MSM.ShoppingBasket.API.Entities
{
    public class PackageDiscount
    {
        public string ProductName { get; set; }

        public int AmountNeededForDiscount { get; set; }

        public string DiscountedProductName { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}
