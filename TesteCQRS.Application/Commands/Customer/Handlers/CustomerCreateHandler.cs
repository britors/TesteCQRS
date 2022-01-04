﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Infra.MessageBroker;
using TesteCQRS.Application.Infra.MessageBroker.Strategies;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponse>
    {
        public async Task<CustomerCreateResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var messageBrokerContext = new MessageBrokerContext<CustomerCreateCommand>(new RabbitMQBroker<CustomerCreateCommand>());
            var queueStatus = messageBrokerContext.AddToQueue(request, request.ProcessName);
            var response = new CustomerCreateResponse
            {
                Id = request.Id,
                ProcessStatus = queueStatus,
                CreatedAt = request.CreatedAt,
                ProcessName = request.ProcessName,
                CorrelationId = request.CorrelationId
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
