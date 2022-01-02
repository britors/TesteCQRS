using Microsoft.Extensions.DependencyInjection;
using TesteCQRS.Application.Commands.Customer.Mappers;

namespace TesteCQRS.Application.Commands
{
    public static class CommandsConfiguration
    {
        public static void MapperObjects(IServiceCollection services)
        {
            CustomerCommandMappers.MakeMappers(services);
        }
    }
}
