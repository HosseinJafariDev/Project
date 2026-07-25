using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Constants;
using Project.Domain.Entities;
using Project.Domain.Entities.Categories;

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
            .HasMaxLength(CategoryConstants.NameMaxLength)
            .IsRequired();

        builder
            .HasMany(x => x.ArticlesCategories)
            .WithOne(c => c.Category)
            .HasForeignKey(f => f.CategoryId);

        builder
            .Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.Metadata
            .FindNavigation(nameof(Category.ArticlesCategories))!
            .SetField("_articleCategories");

        builder.Navigation(x => x.ArticlesCategories)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}