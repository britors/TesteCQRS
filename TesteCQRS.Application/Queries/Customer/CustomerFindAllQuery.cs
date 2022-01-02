using MediatR;
using System.Collections.Generic;
using TesteCQRS.Application.Queries.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Queries.Customer
{
    public class CustomerFindAllQuery : IRequest<IList<CustomerFindAllResponse>>
    {
    }
}
