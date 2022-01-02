using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Domain;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponse>
    {
        public async Task<CustomerCreateResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Name,request.Email);
            var response = new CustomerCreateResponse
            {
                Id = customer.Id
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
