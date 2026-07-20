using Microsoft.AspNetCore.Identity;
using Project.Application.UseCases.Auth.Password;
using Project.Domain.Entities.Users;

namespace Project.Infrastructure.Persistence.Identity.Service.UserService;

public class UserService(UserManager<User> userManager) : IUserService
{
    public async Task<string> GeneratePasswordResetTokenAsync(User user)
    {
        var token = await userManager.GeneratePasswordResetTokenAsync(user!);
        return token;
    }

    public async Task<User?> FindByNameAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);
        return user;
    }
}