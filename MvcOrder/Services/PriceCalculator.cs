using System;
using MvcOrder.Interfaces;
using MvcOrder.Models;

namespace MvcOrder.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IDiscountService _discountService;

        public PriceCalculator(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public decimal CalculateTotal(Order order)
        {
            var subTotal = order.Quantity * order.UnitPrice;

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            } else if ( order.Quantity >= 10)
            {
                subTotal *= 0.90m; // %10 Rabatt
            } else if ( order.Quantity >= 5)
            {
                subTotal *= 0.95m; // %5 Rabatt
            }

            var discountedTotal = _discountService.ApplyDiscount(subTotal);


            var total = subTotal * 1.19m; // 19% MwSt


            return total;

        }
    }
}
