using System;
using MvcOrder.Interfaces;

namespace MvcOrder.Services
{
    public class PaymentService
    {
        //Dieses Logdurch PaymentService mitbenutzt werden zusammen mit dem Controller
        private readonly IRequestLog _log;

        public string LogText { get; set; }

        // "Dependency Injection" des Logs über den Konstruktor
        public PaymentService(IRequestLog log)
        {
            _log = log;
        }

        public void ProcessPayment(decimal amount)
        {
            // Beispielhafte Zahlungsabwicklung
            _log.Add($"PaymentService: Zahlung von {amount:C} wird genehmigt.");
            // Weitere Logik zur Zahlungsabwicklung könnte hier hinzugefügt werden.
            _log.Add($"PaymentService: Zahlung {amount:C} abgeschlossen.");

            var text = $"RequestId: {_log.RequestId} \nLog Entries:\n";

            // Log-Einträge werden an den text angefügt
            foreach (var entry in _log.Entries)
            {
                text += $"{entry}\n";
            }

            LogText = text;
        }

    }
}
