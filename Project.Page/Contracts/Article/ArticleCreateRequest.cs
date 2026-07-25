namespace Project.Page.Contracts.Article;

public class ArticleCreateRequest
{
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public List<int> CategoryIds { get; set; } = null!;
}