using Project.Domain.Entities.ArticleCategories;

namespace Project.Application.interfaces.Repository;

public interface IArticleCategoryRepository : IRepository<ArticleCategory, long>
{
}