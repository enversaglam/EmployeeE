namespace MvcOrder.Models
{
    public class OrderResultViewModel
    {
        public decimal BaseTotal { get; set; }
        public decimal QuantityDiscount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SeasonalDiscount { get; set; }
        public decimal DiscountedTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

    }
}
