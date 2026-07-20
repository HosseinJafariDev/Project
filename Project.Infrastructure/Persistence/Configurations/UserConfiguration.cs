using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Constants;
using Project.Domain.Entities;
using Project.Domain.Entities.Users;

namespace Project.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Firstname)
            .HasColumnType("nvarchar")
            .HasMaxLength(UserConstants.FirstnameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Lastname)
            .HasColumnType("nvarchar")
            .HasMaxLength(UserConstants.LastnameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder
            .HasMany(x => x.Articles)
            .WithOne(x => x.Author)
            .HasForeignKey(a => a.AuthorId);

        builder
            .Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}