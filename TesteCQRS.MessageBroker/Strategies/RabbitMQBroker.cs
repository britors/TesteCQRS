using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using TesteCQRS.MessageBroker.Domain;
using TesteCQRS.MessageBroker.Interfaces;

namespace TesteCQRS.MessageBroker.Strategies
{
    public class RabbitMQBroker<TCommand> : IMessageBrokerStrategy<TCommand> where TCommand : class
    {
        public ProcessStatusEnum AddToQueue(TCommand request, string queueName)
        {
            try
            {

                var factory = new ConnectionFactory() { HostName = "rabbitmq" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                var message = JsonConvert.SerializeObject(request);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: properties,
                             body: body);
                return ProcessStatusEnum.Queue;
            }
            catch (Exception)
            {
                return ProcessStatusEnum.Cancel;
            }
        }
    }
}
