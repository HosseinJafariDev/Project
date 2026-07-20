namespace Project.Application.UseCases.Auth.Login;

public interface ILoginService
{
    Task<bool> LoginAsync(LoginInputDto input);
}