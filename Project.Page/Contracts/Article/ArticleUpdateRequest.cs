namespace Project.Page.Contracts.Article;

public class ArticleUpdateRequest
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreateAt { get; set; }
    public List<int> Categoies { set; get; }
}