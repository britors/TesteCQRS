using System;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer
{
    public class CustomerCreateCommand : QueueCommand<CustomerCreateResponse>
    {
        public Guid Id { get => Guid.NewGuid(); }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
