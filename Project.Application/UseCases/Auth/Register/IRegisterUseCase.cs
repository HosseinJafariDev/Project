namespace Project.Application.UseCases.Auth.Register;

public interface IRegisterUseCase
{
    Task<RegisterOutputDto> ExecuteAsync(RegisterInputDto input);
}