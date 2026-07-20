using System.Reflection.Metadata;
using Project.Domain.Entities.ArticleCategories;
using Project.Domain.Entities.Users;
using Project.Domain.Exceptions;

namespace Project.Domain.Entities.Articles;

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
    public bool IsDeleted { get; private set; } = false;
    private readonly List<ArticleCategory> _list = [];

    public User? Author { get; private set; }
    public IReadOnlyCollection<ArticleCategory>? ArticleCategories => _list.AsReadOnly();

    public Article(long authorId, string title, string content)
    {
        if (authorId <= 0)
            throw new DomainException(ArticleMessages.InvalidAuthorId);

        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(ArticleMessages.TitleRequired);

        if (string.IsNullOrWhiteSpace(content))
            throw new DomainException(ArticleMessages.ContentRequired);

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

    public void Delete() => IsDeleted = true;
}