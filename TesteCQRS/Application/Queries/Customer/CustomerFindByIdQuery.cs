using MediatR;
using System;
using TesteCQRS.Application.Queries.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Queries.Customer
{
    public class CustomerFindByIdQuery : IRequest<CustomerFindByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
