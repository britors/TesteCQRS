using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCQRS.Application.Domain;

namespace TesteCQRS.Application.Queries.Customer.Mappers
{
    public static class CustomerQueriesMappers
    {
        public static void MakeMappers(IServiceCollection services)
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
