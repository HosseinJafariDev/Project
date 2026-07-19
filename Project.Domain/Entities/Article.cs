using System.Reflection.Metadata;

namespace Project.Domain.Entities;

public class Article
{
    private Article()
    {
    }

    public long Id { get; private set; }
    public long AuthorId { get; private set; }
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Article(long authorId, string title, string content)
    {
        AuthorId = authorId;
        Title = title;
        Content = content;
    }

    public void CreatedAted(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public void UpdatedAted(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }

    public User? Author { get; set; }

    public ICollection<ArticleCategory>? ArticleCategories { get; set; }
}