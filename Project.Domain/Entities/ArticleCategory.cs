namespace Project.Domain.Entities;

public class ArticleCategory
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public int CategoryId { get; set; }
    public Article? Article { get; set; }
    public Category? Category { get; set; }
}