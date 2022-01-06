using CustomerCreateCommandWorker.Consumer;
using System;
using TesteCQRS.MessageBroker.Consumer;

namespace CustomerCreateCommandWorker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string queueName = "CustomerCreateCommand";
            var consumer = new RabbitMQConsumer(queueName);
            MessageReceiver receiver = new(consumer.GetChannel());
            consumer.CallReceiver(receiver);
            Console.WriteLine("Worker CustomerCreateCommandWorker Is Workink");
            Console.ReadLine();
        }
    }
}
