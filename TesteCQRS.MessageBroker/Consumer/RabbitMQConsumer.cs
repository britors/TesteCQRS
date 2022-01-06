using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCQRS.MessageBroker.Consumer
{
    public class RabbitMQConsumer
    {
        private readonly IModel _channel;
        private readonly string _queueName;
        
        /// <summary>
        /// Cria uma nova instancia do consumidor
        /// </summary>
        /// <param name="queueName"></param>
        public RabbitMQConsumer(string queueName)
        {
            _queueName = queueName;
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            
        }

        /// <summary>
        /// Retorna o canal criado 
        /// </summary>
        /// <returns></returns>
        public IModel GetChannel() 
            => _channel;

        /// <summary>
        /// Chama a classe para consumir a mensagem
        /// </summary>
        /// <param name="receiver"></param>
        public void CallReceiver(DefaultBasicConsumer receiver)
        =>  _channel.BasicConsume(_queueName, false, receiver);

    }
}
