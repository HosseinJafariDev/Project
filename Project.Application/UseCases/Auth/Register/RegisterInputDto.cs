namespace Project.Application.UseCases.Auth.Register;

public class RegisterInputDto
{
    public string? FirsName { get; set; }
    public string? Lastname { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}