using System;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Commands.Customer.Handlers.Responses
{
    public class CustomerDeleteResponse
    {
        public Guid Id { get; set; }
        public ProcessStatusEnum ProcessStatus { get; set; }
    }
}
