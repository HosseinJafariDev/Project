using Project.Application.interfaces.Repository;
using Project.Domain.Entities;
using Project.Domain.Entities.Articles;

namespace Project.Infrastructure.Persistence.Repositories;

public class ArticleRepository(PageDbContext context) : RepositoryBase<Article, long>(context), IArticleRepository
{
}