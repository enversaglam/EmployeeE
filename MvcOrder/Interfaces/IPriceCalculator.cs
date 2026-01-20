using MvcOrder.Models;

namespace MvcOrder.Interfaces
{
    public interface IPriceCalculator
    {
        decimal CalculateTotal(Order order);
    }
}
