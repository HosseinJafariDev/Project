using Project.Domain.Entities.Users;

namespace Project.Application.UseCases.Auth.Password;

public interface IUserService
{
    public Task<string> GeneratePasswordResetTokenAsync(User user);
    public Task<User?> FindByNameAsync(string username);
}