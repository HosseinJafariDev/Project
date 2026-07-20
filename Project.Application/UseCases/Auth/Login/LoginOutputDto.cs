namespace Project.Application.UseCases.Auth.Login;

public class LoginOutputDto
{
    public string? Message { get; set; }
    public bool Success { get; init; }
}