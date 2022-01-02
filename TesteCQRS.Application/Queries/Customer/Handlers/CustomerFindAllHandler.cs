using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Queries.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Queries.Customer.Handlers
{
    public class CustomerFindAllHandler : IRequestHandler<CustomerFindAllQuery, IList<CustomerFindAllResponse>>
    {
        public async Task<IList<CustomerFindAllResponse>> Handle(CustomerFindAllQuery request, CancellationToken cancellationToken)
        {
            var items = new List<CustomerFindAllResponse>
            {
                new CustomerFindAllResponse
                {
                    Id = Guid.NewGuid(),
                    Email = "rodrigo.brito@fcamara.com.br",
                    Name = "Rodrigo Brito"
                }
            };
            var response = Task.FromResult(items);
            return await response;
        }
    }
}
