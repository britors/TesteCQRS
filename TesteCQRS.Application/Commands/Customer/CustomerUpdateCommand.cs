using System;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Commands.Customer
{
    public class CustomerUpdateCommand : QueueCommand<CustomerUpdateResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
