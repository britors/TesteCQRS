using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteCQRS.Application.Domain;

namespace TesteCQRS.Application.Commands.Customer.Mappers
{
    public static class CustomerCommandMappers
    {
        public static void MakeMappers(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerCreateCommand, CustomerEntity>();
                cfg.CreateMap<CustomerUpdateCommand, CustomerEntity>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
