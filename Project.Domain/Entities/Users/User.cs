using Microsoft.AspNetCore.Identity;
using Project.Domain.Entities.Articles;
using Project.Domain.Exceptions;

namespace Project.Domain.Entities.Users;

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
        if (string.IsNullOrWhiteSpace(firstname))
            throw new DomainException(UserMessages.FirstnameRequired);

        if (string.IsNullOrWhiteSpace(lastname))
            throw new DomainException(UserMessages.LastnameRequired);

        if (string.IsNullOrWhiteSpace(username))
            throw new DomainException(UserMessages.UsernameRequired);
        if (string.IsNullOrWhiteSpace(phone))
            throw new DomainException(UserMessages.PhoneRequired);

        Firstname = firstname;
        Lastname = lastname;
        UserName = username;
        PhoneNumber = phone;
    }

    public void Delete() => IsDeleted = true;
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}