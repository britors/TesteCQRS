using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Infra.MessageBroker;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, CustomerUpdateResponse>
    {
        public async Task<CustomerUpdateResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var queueStatus = RabbitMQHelper.AddToQueue(request, request.ProcessName);
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
