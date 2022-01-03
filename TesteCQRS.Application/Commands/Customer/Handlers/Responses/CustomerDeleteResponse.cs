using System;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public sealed class CustomerDeleteResponse : QueueCommandResponse
    {
        public Guid Id { get; set; }
    }
}
