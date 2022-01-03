using System;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public class CustomerCreateResponse
    {
        public Guid Id { get; set; }
        public ProcessStatusEnum ProcessStatus { get; set; }
    }
}
