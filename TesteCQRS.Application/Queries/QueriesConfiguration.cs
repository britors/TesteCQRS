using Microsoft.Extensions.DependencyInjection;
using TesteCQRS.Application.Queries.Customer.Mappers;

namespace TesteCQRS.Application.Queries
{
    public static class QueriesConfiguration
    {
        public static void MapperObjects(IServiceCollection services)
        {
            CustomerQueriesMappers.MakeMappers(services);
        }
    }
}
