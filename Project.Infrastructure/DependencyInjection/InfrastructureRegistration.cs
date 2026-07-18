using Microsoft.Extensions.DependencyInjection;

namespace Project.Infrastructure.DependencyInjection;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}