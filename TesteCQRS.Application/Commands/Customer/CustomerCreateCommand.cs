using System;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer
{
    public class CustomerCreateCommand : QueueCommand<CustomerCreateResponse>
    {
        public CustomerCreateCommand()
            =>  Id = Guid.NewGuid();

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
