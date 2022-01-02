using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, CustomerDeleteResponse>
    {
        public async Task<CustomerDeleteResponse> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new CustomerDeleteResponse
            {
                Id = request.Id,
                Success = true
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
