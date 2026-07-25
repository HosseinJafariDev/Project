using Project.Domain.Entities.Articles;
using Project.Domain.Entities.Categories;
using Project.Domain.Exceptions;

namespace Project.Domain.Entities.ArticleCategories;

public class ArticleCategory
{
    private ArticleCategory()
    {
    }

    public long Id { get; private set; }
    public long ArticleId { get; private set; }
    public int CategoryId { get; private set; }
    public Article? Article { get; private set; }
    public Category? Category { get; private set; }

    public ArticleCategory(long id, int categoryId, long articleId)
    {
        if (categoryId <= 0)
            throw new DomainException(ArticleCategoryMessages.InvalidArticleId);
        Id = id;
        ArticleId = articleId;
        CategoryId = categoryId;
    }
}