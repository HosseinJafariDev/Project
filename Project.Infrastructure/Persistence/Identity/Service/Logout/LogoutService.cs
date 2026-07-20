using Microsoft.AspNetCore.Identity;
using Project.Application.UseCases.Auth.Logout;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Identity.Service.Logout;

public class LogoutService(SignInManager<User> signInManager) : ILogoutService
{
    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}