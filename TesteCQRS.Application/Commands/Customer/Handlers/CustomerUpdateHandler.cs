using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer.Handlers.Responses;
using TesteCQRS.Application.Domain;
using TesteCQRS.Application.Domain.Enums;

namespace TesteCQRS.Application.Commands.Customer.Handlers
{
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, CustomerUpdateResponse>
    {
        private readonly IMapper _mapper;
        public CustomerUpdateHandler(IMapper mapper) =>
           _mapper = mapper;

        public async Task<CustomerUpdateResponse> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerEntity>(request);
            var response = new CustomerUpdateResponse
            {
                Id = customer.Id,
                ProcessStatus = ProcessStatusEnum.Queue
            };
            var result = Task.FromResult(response);
            return await result;
        }
    }
}
