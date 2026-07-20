namespace Project.Application.UseCases.Auth.Password;

public class ForgotPasswordUseCase(IForgotPasswordService forgotPasswordService, IUserService userService)
    : IForgotPasswordUseCase
{
    public async Task<ForgotPasswordOutputDto> ExecuteAsync(string username, string newPassword)
    {
        var user = await userService.FindByNameAsync(username);
        if (user == null)
        {
            return new ForgotPasswordOutputDto()
            {
                Success = false,
                Message = "User not found"
            };
        }

        var token = await userService.GeneratePasswordResetTokenAsync(user);
        var result = await forgotPasswordService.ForgotPasswordAsync(user, token, newPassword);
        return result;
    }
}