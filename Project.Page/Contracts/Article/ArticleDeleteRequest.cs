namespace Project.Page.Contracts.Article;

public class ArticleDeleteRequest
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}