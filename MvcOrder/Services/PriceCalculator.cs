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
        public OrderResultViewModel CalculateTotal(Order order)
        {
            var subTotal = order.Quantity * order.UnitPrice;
            decimal quantityDiscount = 0m;

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            } else if ( order.Quantity >= 10)
            {
                quantityDiscount = subTotal * 0.10m;
                subTotal -= quantityDiscount; // %10 Rabatt
            } else if ( order.Quantity >= 5)
            {
                quantityDiscount = subTotal * 0.05m;
                subTotal -= quantityDiscount; // %5 Rabatt
            }

            var discountedTotal = _discountService.ApplyDiscount(subTotal);


            var total = discountedTotal * 1.19m; // 19% MwSt


            return new OrderResultViewModel
            {
                BaseTotal = order.Quantity * order.UnitPrice,
                QuantityDiscount = quantityDiscount,
                SubTotal = subTotal,
                SeasonalDiscount = subTotal - discountedTotal,
                DiscountedTotal = discountedTotal,
                Tax = total - discountedTotal,
                Total = total
            };

        }
    }
}
