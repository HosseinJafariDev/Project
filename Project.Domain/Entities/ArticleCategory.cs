namespace Project.Domain.Entities;

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
        ArticleId = articleId;
        CategoryId = categoryId;
    }
}