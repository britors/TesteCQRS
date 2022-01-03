using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, CustomerDeleteResponse>
    {
        public async Task<CustomerDeleteResponse> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomerDeleteResponse
            {
                Id = request.Id,
                ProcessStatus = ProcessStatusEnum.Queue,
                CorrelationId = request.CorrelationId
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
