using Microsoft.AspNetCore.Mvc;
using MvcOrder.Interfaces;
using MvcOrder.Models;

namespace MvcOrder.Controllers
{
    public class OrderController : Controller
    {
        // Abhängigkeitseinfügung des PriceCalculator-Dienstes
        private readonly IPriceCalculator _priceCalculator;

        // Konstruktor
        public OrderController(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                // Verwenden des PriceCalculator-Dienstes zur Berechnung des Gesamtpreises
                var total = _priceCalculator.CalculateTotal(order);
                ViewBag.Total = total;
            }
            return View(order);
        }

        // Zum Testen benötigen wir eine Action-Methode, die für uns die
        // Preisberechnung auf Basis der gegebenen Daten durchführt.
        // Diese Berechnung nutzt dann den injizierten Service.
        // Order/CalculatePrice?quantity=10&price=19.99

        public IActionResult CalculatePrice(int quantity, decimal price)
        {
            var bestellung = new Order()
            {
                Quantity = quantity,
                UnitPrice = price
            };

            var totalPrice = _priceCalculator.CalculateTotal(bestellung);

            return Content($"Der Gesamtpreis beträgt: {totalPrice:C}");
        }
    }
}
