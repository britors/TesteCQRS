using MediatR;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer
{
    public class CustomerCreateCommand : IRequest<CustomerCreateResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
