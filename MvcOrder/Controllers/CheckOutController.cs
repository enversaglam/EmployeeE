using System;
using Microsoft.AspNetCore.Mvc;
using MvcOrder.Services;
using MvcOrder.Interfaces;

namespace MvcOrder.Controllers
{
    public class CheckOutController : Controller
    {
        // Dieser Checkout -Controller verwendet zwei Services
        private readonly PaymentService _paymentService;
        private readonly IRequestLog _requestLog;

        // Konstruktor, in dem die Abhängigkeiten injiziert werden
        public CheckOutController(PaymentService paymentService, IRequestLog requestLog)
        {
            _paymentService = paymentService;
            _requestLog = requestLog;
        }

        // Implementierung eines Endpunkts, der RequestLog verwendet NEBEN dem Service Payment Service
        public IActionResult ProcessPayment(decimal amount)
        {
            // Logge die Anfrage
            _requestLog.Add($"Payment processed for amount: {amount}");
            // Verwende den PaymentService, um die Zahlung zu verarbeiten
            _paymentService.ProcessPayment(amount);

            _requestLog.Add($"Controller: Payment of amount: {amount} processed successfully.");

            // Ausgabe des Logs vorbereiten
            // Wurde auch alles geloggt?
            var text = $"RequestId: {_requestLog.RequestId} \nLog Entries:\n";

            // Log-Einträge werden an den text angefügt
            foreach (var entry in _requestLog.Entries)
            {
                text += $"{entry}\n";
            }

            text += _paymentService.LogText;

            return Content(text);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
