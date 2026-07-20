namespace Project.Application.UseCases.Auth.Password;

public interface IForgotPasswordUseCase
{
    Task<ForgotPasswordOutputDto> ExecuteAsync(string username, string newPassword);
}