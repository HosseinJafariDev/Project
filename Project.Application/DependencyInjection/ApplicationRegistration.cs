using Microsoft.Extensions.DependencyInjection;

namespace Project.Application.DependencyInjection;

public static class ApplicationRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}