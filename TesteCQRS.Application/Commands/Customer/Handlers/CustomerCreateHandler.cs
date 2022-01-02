using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Domain;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, CustomerCreateResponse>
    {
        private readonly IMapper _mapper;
        public CustomerCreateHandler(IMapper mapper) =>
           _mapper = mapper;

        public async Task<CustomerCreateResponse> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerModel>(request);
            var response = new CustomerCreateResponse
            {
                Id = customer.Id
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
