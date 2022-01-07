using System;

namespace CustomerCreateCommandWorker.Consumer
{
    internal class Message
    {
        public Message(Guid id, string name, string email, Guid correlationId, string processName, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CorrelationId = correlationId;
            ProcessName = processName;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid CorrelationId { get; private set; }
        public string ProcessName { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
