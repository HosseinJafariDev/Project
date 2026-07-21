using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Project.Domain.Entities;
using Project.Domain.Entities.Roles;
using Project.Domain.Entities.Users;
using Project.Domain.Enums;
using Project.Infrastructure.Persistence.Identity.Options;

namespace Project.Infrastructure.Persistence.Identity;

public class IdentitySeeder(RoleManager<Role> roleManager, UserManager<User> userManager, IOptions<AdminOption> options)
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

    public async Task SeedAdminAsync()
    {
        var admin = await userManager.FindByNameAsync(options.Value.Username);

        if (admin != null)
            return;

        admin = new User(options.Value.Firstname, options.Value.Lastname, options.Value.Username,
            options.Value.Password);

        await userManager.CreateAsync(admin, options.Value.Password);
        await userManager.AddToRoleAsync(admin, nameof(Roles.Admin));
    }
}