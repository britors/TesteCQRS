using MediatR;
using System;

namespace TesteCQRS.Application.Commands
{
    public abstract class QueueCommand<TCommand> : IRequest<TCommand> where TCommand: class
    {
        public Guid CorrelationId { get => Guid.NewGuid(); }
        public string ProcessName { get => GetType().Name; }
        public DateTime CreatedAt { get => DateTime.UtcNow; }

    }
}
