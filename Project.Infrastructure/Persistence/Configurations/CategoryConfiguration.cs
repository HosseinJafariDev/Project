using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable("Categories");

        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(x => x.ArticlesCategories)
            .WithOne(c => c.Category)
            .HasForeignKey(f => f.CategoryId);
    }
}