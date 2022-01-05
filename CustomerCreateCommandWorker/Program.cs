using CustomerCreateCommandWorker.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CustomerCreateCommandWorker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string queueName = "CustomerCreateCommand";
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                Console.WriteLine("nova mensagem recebida");
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
                var customerCreate = JsonConvert.DeserializeObject<CustomerCreate>(message);

            };

            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Worker CustomerCreateCommandWorker Start");
            Console.ReadLine();
        }
    }
}
