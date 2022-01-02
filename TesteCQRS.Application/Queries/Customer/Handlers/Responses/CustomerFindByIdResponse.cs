using System;

namespace TesteCQRS.Application.Queries.Customer.Handlers.Responses
{
    public class CustomerFindByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
