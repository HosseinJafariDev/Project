namespace Project.Application.UseCases.Auth.Login;

public interface ILoginUseCase
{
    Task<LoginOutputDto> ExecuteAsync(LoginInputDto input);
}