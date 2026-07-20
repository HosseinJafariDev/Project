using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;
using Project.Domain.Entities.ArticleCategories;

namespace Project.Infrastructure.Persistence.Configurations;

public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder
            .ToTable("ArticleCategories");

        builder
            .HasKey(x => x.Id);
    }
}