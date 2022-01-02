using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Domain;
using TesteCQRS.Application.Queries.Customer.Handlers.Responses;

namespace TesteCQRS.Application.Queries.Customer.Handlers
{
    public class CustomerFindByIdHandler : IRequestHandler<CustomerFindByIdQuery, CustomerFindByIdResponse>
    {
        private readonly IMapper _mapper;
        public CustomerFindByIdHandler(IMapper mapper) =>
           _mapper = mapper;

        public async Task<CustomerFindByIdResponse> Handle(CustomerFindByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerModel>(request);
            var item = new CustomerFindByIdResponse
            {
                Id = customer.Id,
                Email = "rodrigo.brito@fcamara.com.br",
                Name = "Rodrigo Brito"
            };

            var response = Task.FromResult(item);
            return await response;
        }
    }
}
