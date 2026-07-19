using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Configurations;

public class ArticleCategoryConfiguration : IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder
            .ToTable("ArticleCategories");

        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.Article)
            .WithMany(x => x.ArticleCategories)
            .HasForeignKey(x => x.ArticleId);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.ArticlesCategories)
            .HasForeignKey(x => x.CategoryId);
    }
}