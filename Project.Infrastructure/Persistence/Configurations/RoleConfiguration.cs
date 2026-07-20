using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using Project.Domain.Entities.Roles;

namespace Project.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("Roles");

        builder
            .Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder
            .Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}