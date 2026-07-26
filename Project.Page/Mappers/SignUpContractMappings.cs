using Project.Application.UseCases.Auth.Register;
using Project.Page.Contracts.Auth;

namespace Project.Page.Mappers;

public static class SignUpContractMappings
{
    public static RegisterInputDto ToRegisterInputDto(this SignUpRequest signUpRequest)
    {
        return new RegisterInputDto()
        {
            FirsName = signUpRequest.FirsName,
            Lastname = signUpRequest.Lastname,
            Password = signUpRequest.Password,
            Username = signUpRequest.Username,
            PhoneNumber = signUpRequest.PhoneNumber,
        };
    }
}