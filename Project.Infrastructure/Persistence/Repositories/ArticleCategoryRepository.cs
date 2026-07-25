using Project.Application.interfaces.Repository;
using Project.Domain.Entities.ArticleCategories;

namespace Project.Infrastructure.Persistence.Repositories;

public class ArticleCategoryRepository(PageDbContext context)
    : RepositoryBase<ArticleCategory, long>(context), IArticleCategoryRepository
{
}