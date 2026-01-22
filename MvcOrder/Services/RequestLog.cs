using System;
using MvcOrder.Interfaces;

namespace MvcOrder.Services
{
    public class RequestLog : IRequestLog
    {
        public Guid RequestId { get; } = Guid.NewGuid();
        private readonly List<string> _entries = new();

        public IReadOnlyList<string> Entries => _entries; // return entries

        public void Add(string message)
        {
            _entries.Add(message);
        }
    }
}

