using TesteCQRS.MessageBroker.Domain;
using TesteCQRS.MessageBroker.Interfaces;

namespace TesteCQRS.MessageBroker
{
    public class MessageBrokerContext<TCommand> where TCommand : class
    {
        private readonly IMessageBrokerStrategy<TCommand> _strategy;

        public MessageBrokerContext(IMessageBrokerStrategy<TCommand> strategy)
            => _strategy = strategy;

        public ProcessStatusEnum AddToQueue(TCommand request, string queueName)
        {
            return _strategy.AddToQueue(request, queueName);
        }
    }
}
