using ProductApp.Models;
using System;

namespace ProductApp
{
    public static class ProductHelper
    {
        public static bool IsOnSale(int discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage >= 100)
            {
                throw new ArgumentOutOfRangeException("Discount must be larger than 0 and less than 100");
            }

            if (discountPercentage == 0)
            {
                return false;
            }
            return true;
        }

        public static double GetDiscountedPrice(Product product)
        {
            double price = product.Price;
            int discountPercentage = product.DiscountPercentage;
            if (IsOnSale(product.DiscountPercentage) == false)
            {
                return price;
            }

            return price - (price * discountPercentage / 100);
        }
    }
}
