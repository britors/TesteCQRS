using System;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public class CustomerUpdateResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
    }
}
