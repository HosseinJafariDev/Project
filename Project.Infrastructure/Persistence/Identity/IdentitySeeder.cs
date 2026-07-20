using Microsoft.AspNetCore.Identity;
using Project.Domain.Entities;
using Project.Domain.Enums;

namespace Project.Infrastructure.Persistence.Identity;

public class IdentitySeeder(RoleManager<Role> roleManager)
{
    public async Task SeedRolesAsync()
    {
        if (!await roleManager.RoleExistsAsync(nameof(Roles.Admin)))
        {
            await roleManager.CreateAsync(new Role(nameof(Roles.Admin)));
        }

        if (!await roleManager.RoleExistsAsync(nameof(Roles.Author)))
        {
            await roleManager.CreateAsync(new Role(nameof(Roles.Author)));
        }

        if (!await roleManager.RoleExistsAsync(nameof(Roles.User)))
        {
            await roleManager.CreateAsync(new Role(nameof(Roles.User)));
        }
    }
}