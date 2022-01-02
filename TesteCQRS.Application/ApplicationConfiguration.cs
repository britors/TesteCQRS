using Microsoft.Extensions.DependencyInjection;
using TesteCQRS.Application.Commands;
using TesteCQRS.Application.Queries;

namespace TesteCQRS.Application
{
    public static class ApplicationConfiguration
    {
        public static void MapperObjects(IServiceCollection services)
        {
            CommandsConfiguration.MapperObjects(services);
            QueriesConfiguration.MapperObjects(services);
        }
    }
}
