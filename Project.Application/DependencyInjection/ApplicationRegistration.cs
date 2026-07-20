using Microsoft.Extensions.DependencyInjection;
using Project.Application.UseCases.Auth.Login;
using Project.Application.UseCases.Auth.Logout;
using Project.Application.UseCases.Auth.Password;
using Project.Application.UseCases.Auth.Register;

namespace Project.Application.DependencyInjection;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<ILogoutUseCase, LogoutUseCase>();
        services.AddScoped<IForgotPasswordUseCase, ForgotPasswordUseCase>();
        services.AddScoped<IRegisterUseCase, RegisterUseCase>();
        return services;
    }
}