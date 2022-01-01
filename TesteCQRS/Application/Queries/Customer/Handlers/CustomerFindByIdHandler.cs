using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Queries.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Queries.Customer.Handlers
{
    public class CustomerFindByIdHandler : IRequestHandler<CustomerFindByIdQuery, CustomerFindByIdResponse>
    {
        public async Task<CustomerFindByIdResponse> Handle(CustomerFindByIdQuery request, CancellationToken cancellationToken)
        {

            var item = new CustomerFindByIdResponse
            {
                Id = request.Id,
                Email = "rodrigo.brito@fcamara.com.br",
                Name = "Rodrigo Brito"
            };
            
            var response = Task.FromResult(item);
            return await response;
            
        }
    }
}
