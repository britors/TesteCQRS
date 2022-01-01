using System;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public class CustomerDeleteResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
    }
}
