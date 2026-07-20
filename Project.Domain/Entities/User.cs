using Microsoft.AspNetCore.Identity;

namespace Project.Domain.Entities;

public class User : IdentityUser<long>
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public override string? PhoneNumber { get; set; }
    public override string? UserName { get; set; }
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    private readonly List<Article> _list = [];

    public IReadOnlyCollection<Article> Articles => _list.AsReadOnly();

    private User()
    {
    }

    public User(string firstname, string lastname, string username, string phone)
    {
        Firstname = firstname;
        Lastname = lastname;
        UserName = username;
        PhoneNumber = phone;
    }

    public void Delete() => IsDeleted = true;
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}