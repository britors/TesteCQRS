using MediatR;
using System;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer
{
    public class CustomerDeleteCommand : IRequest<CustomerDeleteResponse>
    {
        public Guid Id { get; set; }
    }
}
