using Microsoft.AspNetCore.Identity;

namespace Project.Domain.Entities;

public class User : IdentityUser<long>
{
    private readonly List<Article> _list = [];
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;

    public IReadOnlyCollection<Article> Articles => _list.AsReadOnly();

    private User()
    {
    }

    public User(string firstname, string lastname, string username)
    {
        Firstname = firstname;
        Lastname = lastname;
        UserName = username;
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}