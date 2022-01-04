using System;
using TesteCQRS.Application.Domain.Enums;
using TesteCQRS.Application.Infra.MessageBroker.Interfaces;

namespace TesteCQRS.Application.Infra.MessageBroker
{
    public class MessageBrokerContext<TCommand> where TCommand : class
    {
        private IMessageBrokerStrategy<TCommand> _strategy;

        public MessageBrokerContext(IMessageBrokerStrategy<TCommand> strategy) 
            => _strategy = strategy;

        public ProcessStatusEnum AddToQueue(TCommand request, string queueName)
        {
            return _strategy.AddToQueue(request, queueName);
        }
    }
}
