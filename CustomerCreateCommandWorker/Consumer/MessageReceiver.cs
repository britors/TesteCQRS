﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessageReceiver(IModel channel)
        {
            _channel = channel;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Message, Customer>();
            });

            _mapper = config.CreateMapper();
        }

        public override void HandleBasicDeliver(string consumerTag,
            ulong deliveryTag,
            bool redelivered,
            string exchange,
            string routingKey,
            IBasicProperties properties,
            ReadOnlyMemory<byte> body)
        {
            Console.WriteLine("Recebendo Mensagem");

            var content = Encoding.UTF8.GetString(body.ToArray());
            var message = JsonConvert.DeserializeObject<Message>(content);
            var creator = new CustomerCreator();
            var customer = _mapper.Map<Customer>(message);
            creator.Create(customer);
            _channel.BasicAck(deliveryTag, false);
        }
    }
}
