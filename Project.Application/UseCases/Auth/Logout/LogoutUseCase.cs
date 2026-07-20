namespace Project.Application.UseCases.Auth.Logout;

public class LogoutUseCase(ILogoutService logoutService) : ILogoutUseCase
{
    public async Task ExecuteAsync()
    {
        await logoutService.LogoutAsync();
    }
}