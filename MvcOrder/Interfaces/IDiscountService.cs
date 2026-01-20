namespace MvcOrder.Interfaces
{
    public interface IDiscountService
    {
        decimal ApplyDiscount(decimal totalPrice);
    }
}
