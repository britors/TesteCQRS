using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Domain;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, CustomerUpdateResponse>
    {
        public async Task<CustomerUpdateResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Id, request.Name, request.Email);
            var response = new CustomerUpdateResponse
            {
                Id = customer.Id,
                Success = true
            };
            var result = Task.FromResult(response);
            return await result;
        }


    }
}
