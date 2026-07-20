namespace Project.Application.UseCases.Auth.Login;

public class LoginInputDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}