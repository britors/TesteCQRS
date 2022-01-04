using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteCQRS.Application.Domain;
using TesteCQRS.Application.Queries.Customer;

namespace TesteCQRS.Application
{
    public static class ApplicationConfiguration
    {
        public static void MapperObjects(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerFindByIdQuery, CustomerEntity>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
