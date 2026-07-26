using Project.Application.UseCases.Auth.Login;
using Project.Page.Contracts.Auth;

namespace Project.Page.Mappers;

public static class LoginContractMappings
{
    public static LoginInputDto ToLoginInputDto(this LoginRequest loginRequest)
    {
        return new LoginInputDto()
        {
            Password = loginRequest.Password,
            Username = loginRequest.Username,
            RememberMe = loginRequest.RememberMe
        };
    }
}