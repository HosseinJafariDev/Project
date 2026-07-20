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

    public ArticleCategory(int categoryId, long articleId)
    {
        if (articleId <= 0)
            throw new DomainException(ArticleCategoryMessages.InvalidArticleCategoryId);

        if (categoryId <= 0)
            throw new DomainException(ArticleCategoryMessages.InvalidArticleId);

        ArticleId = articleId;
        CategoryId = categoryId;
    }
}