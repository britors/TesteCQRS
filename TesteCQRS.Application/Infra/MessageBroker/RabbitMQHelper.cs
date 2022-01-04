using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Infra.MessageBroker
{
    public static class RabbitMQHelper
    {
        public static ProcessStatusEnum AddToQueue<TCommand>(TCommand request, string queueName) where TCommand : class
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "rabbitmq" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                var message = JsonConvert.SerializeObject(request);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
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
