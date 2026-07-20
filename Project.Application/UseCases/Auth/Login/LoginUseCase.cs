namespace Project.Application.UseCases.Auth.Login;

public class LoginUseCase(ILoginService loginService) : ILoginUseCase
{
    public async Task<LoginOutputDto> ExecuteAsync(LoginInputDto input)
    {
        var result = await loginService.LoginAsync(input);
        return new LoginOutputDto()
        {
            Success = result,
            Message = result ? "" : "نام کاربری یا رمز عبور اشتباه است."
        };
    }
}