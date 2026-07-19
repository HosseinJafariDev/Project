using Microsoft.AspNetCore.Identity;

namespace Project.Domain.Entities;

public class Role : IdentityRole<long>
{
    private Role()
    {
    }

    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}