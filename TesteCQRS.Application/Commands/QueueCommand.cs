using MediatR;
using System;

namespace TesteCQRS.Application.Commands
{
    public abstract class QueueCommand<TCommand> : IRequest<TCommand> where TCommand: class
    {
        public QueueCommand()
        {
            CorrelationId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            ProcessName = GetType().Name;
        }

        public Guid CorrelationId { get; private set; }
        public string ProcessName { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
