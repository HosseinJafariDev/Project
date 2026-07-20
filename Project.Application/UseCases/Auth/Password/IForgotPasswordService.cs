using Project.Domain.Entities;
using Project.Domain.Entities.Users;

namespace Project.Application.UseCases.Auth.Password;

public interface IForgotPasswordService
{
    Task<ForgotPasswordOutputDto> ForgotPasswordAsync(User user, string token, string newPassword);
}