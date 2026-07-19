using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Configurations;

public class ArticlesConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .ToTable("Articles");

        builder
            .Property(x => x.Title)
            .HasColumnType("nvarchar")
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(x => x.Content)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder
            .HasMany(x => x.ArticleCategories)
            .WithOne(c => c.Article)
            .HasForeignKey(x => x.ArticleId);
    }
}