using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Infra.MessageBroker.Interfaces
{
    public interface IMessageBrokerStrategy<TCommand> where TCommand : class
    {
        ProcessStatusEnum AddToQueue(TCommand request, string queueName);
    }
}
