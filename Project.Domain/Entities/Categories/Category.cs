using Project.Domain.Entities.ArticleCategories;
using Project.Domain.Exceptions;

namespace Project.Domain.Entities.Categories;

public class Category
{
    private Category()
    {
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public bool IsDeleted { get; private set; } = false;
    private readonly List<ArticleCategory> _articleCategories = [];

    public IReadOnlyCollection<ArticleCategory>? ArticlesCategories => _articleCategories;

    public Category(int id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException(CategoryMessages.CategoryNameRequired);
        Id = id;
        Name = name;
    }

    public void Delete() => IsDeleted = true;
}