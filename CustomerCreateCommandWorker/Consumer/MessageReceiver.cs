using CustomerCreateCommandWorker.Application.Service;
using CustomerCreateCommandWorker.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CustomerCreateCommandWorker.Consumer
{
    internal class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        public MessageReceiver(IModel channel) =>
            _channel = channel;


        public override void HandleBasicDeliver(string consumerTag,
            ulong deliveryTag,
            bool redelivered,
            string exchange,
            string routingKey,
            IBasicProperties properties,
            ReadOnlyMemory<byte> body)
        {
            Console.WriteLine("Recebendo Mensagem");
            var message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine(message);
            var customer = JsonConvert.DeserializeObject<Customer>(message);
            var creator = new CustomerCreator();
            creator.Create(customer);
            _channel.BasicAck(deliveryTag, false);
        }
    }
}
