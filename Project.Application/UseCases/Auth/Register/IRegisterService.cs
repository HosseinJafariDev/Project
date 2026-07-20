namespace Project.Application.UseCases.Auth.Register;

public interface IRegisterService
{
    Task<RegisterOutputDto> RegisterAsync(RegisterInputDto input);
}