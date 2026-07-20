using Project.Application.UseCases.Auth.Login;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Project.Infrastructure.Persistence.Identity.Service.Login;

public class LoginService(SignInManager<User> signInManager) : ILoginService
{
    public async Task<bool> LoginAsync(LoginInputDto input)
    {
        var result = await signInManager.PasswordSignInAsync(
            input.Username,
            input.Password,
            input.RememberMe,
            lockoutOnFailure: true);

        return result.Succeeded;
    }
}