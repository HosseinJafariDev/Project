using Project.Page.Contracts;

namespace Project.Page.Contracts;

public class ArticleResponse
{
    public string? Title { get; set; }
    public DateTime ReleaseTime { get; set; }
    public List<ParagraphResponse>? Paragraphs { get; set; }
}