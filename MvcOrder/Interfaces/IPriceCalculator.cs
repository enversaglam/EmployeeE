using MvcOrder.Models;

namespace MvcOrder.Interfaces
{
    public interface IPriceCalculator
    {
        OrderResultViewModel CalculateTotal(Order order);
    }
}
