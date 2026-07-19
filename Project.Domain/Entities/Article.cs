using System.Reflection.Metadata;

namespace Project.Domain.Entities;

public class Article
{
    private Article()
    {
    }

    private readonly List<ArticleCategory> _list = [];
    public long Id { get; private set; }
    public long AuthorId { get; private set; }
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public User? Author { get; private set; }
    public IReadOnlyCollection<ArticleCategory>? ArticleCategories => _list.AsReadOnly();

    public Article(long authorId, string title, string content)
    {
        AuthorId = authorId;
        Title = title;
        Content = content;
    }

    public void AddCategory(int categoryId)
    {
        var item = new ArticleCategory(categoryId, Id);
        _list.Add(item);
    }

    public void CreatedAted(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public void UpdatedAted(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}