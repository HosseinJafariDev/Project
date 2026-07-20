using Microsoft.AspNetCore.Identity;
using Project.Application.UseCases.Auth.Register;
using Project.Domain.Entities;
using Project.Domain.Enums;

namespace Project.Infrastructure.Persistence.Identity.Service.Register;

public class RegisterService(UserManager<User> userManager) : IRegisterService
{
    public async Task<RegisterOutputDto> RegisterAsync(RegisterInputDto input)
    {
        var user = new User(input.FirsName!, input.Lastname!, input.Username, input.PhoneNumber);

        var result = await userManager.CreateAsync(user, input.Password);

        if (!result.Succeeded)
        {
            return new RegisterOutputDto()
            {
                Success = result.Succeeded,
                Message = result.Errors.First().Description
            };
        }

        await userManager.AddToRoleAsync(user, nameof(Roles.User));

        return new RegisterOutputDto()
        {
            Success = result.Succeeded,
        };
    }
}