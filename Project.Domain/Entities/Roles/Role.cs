using Microsoft.AspNetCore.Identity;
using Project.Domain.Exceptions;

namespace Project.Domain.Entities.Roles;

public class Role : IdentityRole<long>
{
    private Role()
    {
    }

    public Role(string name) : base(name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException(RoleMessages.RoleNameRequired);
    }

    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;

    public void Delete() => IsDeleted = true;
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}