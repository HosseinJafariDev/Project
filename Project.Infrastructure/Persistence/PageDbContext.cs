using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Entities.ArticleCategories;
using Project.Domain.Entities.Articles;
using Project.Domain.Entities.Categories;
using Project.Domain.Entities.Roles;
using Project.Domain.Entities.Users;

namespace Project.Infrastructure.Persistence;

public class PageDbContext(DbContextOptions<PageDbContext> options)
    : IdentityDbContext<User, Role, long>(options)
{
    DbSet<Category> Categories { get; set; }
    DbSet<Article> Articles { get; set; }
    DbSet<ArticleCategory> ArticleCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}