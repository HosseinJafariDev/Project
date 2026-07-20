using Microsoft.AspNetCore.Identity;
using Project.Application.UseCases.Auth.Password;
using Project.Domain.Entities;
using Project.Domain.Entities.Users;

namespace Project.Infrastructure.Persistence.Identity.Service.Password;

public class ForgotPasswordService(UserManager<User> userManager) : IForgotPasswordService
{
    public async Task<ForgotPasswordOutputDto> ForgotPasswordAsync(User user, string token, string newPassword)
    {
        var result = await userManager.ResetPasswordAsync(user!, token, newPassword);

        return new ForgotPasswordOutputDto()
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Password reset successful" : result.Errors.First().Description
        };
    }
}