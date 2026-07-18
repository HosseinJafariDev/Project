namespace Project.Page.Pages.Models;

public class ArticleResponse
{
    public string? Title { get; set; }
    public DateTime ReleaseTime { get; set; }
    public List<ParagraphResponse>? Paragraphs { get; set; }
}