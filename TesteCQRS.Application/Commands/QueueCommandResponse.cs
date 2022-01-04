using System;
using TesteCQRS.MessageBroker.Domain;

namespace TesteCQRS.Application.Commands
{
    public abstract class QueueCommandResponse
    {
        public Guid CorrelationId { get; set; }
        public string ProcessName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProcessStatusEnum ProcessStatus { get; set; }
    }
}
