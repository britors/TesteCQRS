using System;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public sealed class CustomerCreateResponse : QueueCommandResponse
    {
        public Guid Id { get; set; }
    }
}
