using TesteCQRS.MessageBroker.Domain;

namespace TesteCQRS.MessageBroker.Interfaces
{
    public interface IMessageBrokerStrategy<TCommand> where TCommand : class
    {
        ProcessStatusEnum AddToQueue(TCommand request, string queueName);
    }
}
