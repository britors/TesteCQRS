using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Infra.MessageBroker;
using TesteCQRS.Application.Infra.MessageBroker.Strategies;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, CustomerUpdateResponse>
    {
        public async Task<CustomerUpdateResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var messageBrokerContext = new MessageBrokerContext<CustomerUpdateCommand>(new RabbitMQBroker<CustomerUpdateCommand>());
            var queueStatus = messageBrokerContext.AddToQueue(request, request.ProcessName);

            var response = new CustomerUpdateResponse
            {
                Id = request.Id,
                ProcessStatus = queueStatus,
                ProcessName = request.ProcessName,
                CreatedAt = request.CreatedAt,
                CorrelationId = request.CorrelationId
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
