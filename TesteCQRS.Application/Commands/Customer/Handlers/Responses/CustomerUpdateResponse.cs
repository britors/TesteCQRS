using System;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public sealed class CustomerUpdateResponse: QueueCommandResponse
    {
        public Guid Id { get; set; }
    }
}
