using Microsoft.Extensions.DependencyInjection;

namespace Project.Application.DependencyInjection;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}