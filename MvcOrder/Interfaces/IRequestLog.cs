namespace MvcOrder.Interfaces
{
    public interface IRequestLog
    {
        Guid RequestId { get; }
        void Add(string message);

        IReadOnlyList<string> Entries { get; }
    }
}
