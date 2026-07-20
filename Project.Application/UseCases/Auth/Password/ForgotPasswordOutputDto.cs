namespace Project.Application.UseCases.Auth.Password;

public class ForgotPasswordOutputDto
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}