using System.ComponentModel.DataAnnotations;

namespace Project.Page.Contracts.Auth;

public class SignUpRequest
{
    [Required] public string? FirsName { get; set; }
    [Required] public string? Lastname { get; set; }
    [Required] public string Username { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;
    [Required] public string PhoneNumber { get; set; } = null!;
}