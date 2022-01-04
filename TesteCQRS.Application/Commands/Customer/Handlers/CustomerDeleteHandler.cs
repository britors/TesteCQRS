using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.MessageBroker;
using TesteCQRS.MessageBroker.Strategies;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, CustomerDeleteResponse>
    {
        public async Task<CustomerDeleteResponse> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var messageBrokerContext = new MessageBrokerContext<CustomerDeleteCommand>(new RabbitMQBroker<CustomerDeleteCommand>());
            var queueStatus = messageBrokerContext.AddToQueue(request, request.ProcessName);
            var response = new CustomerDeleteResponse
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
