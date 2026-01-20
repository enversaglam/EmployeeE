using System;
using MvcOrder.Interfaces;

namespace MvcOrder.Services
{
    public class BlackFridayDiscountService : IDiscountService
    {
        public decimal ApplyDiscount(decimal totalPrice)
        {
            // Black Friday Rabatt von 30%
            decimal discountRate = 0.30m;
            return totalPrice - (totalPrice * discountRate);
        }
    }
}
