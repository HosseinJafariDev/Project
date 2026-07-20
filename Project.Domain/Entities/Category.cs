namespace Project.Domain.Entities;

public class Category
{
    private Category()
    {
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public bool IsDeleted { get; private set; } = false;
    private readonly List<ArticleCategory> _articleCategories = [];

    public IReadOnlyCollection<ArticleCategory>? ArticlesCategories => _articleCategories.AsReadOnly();

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Delete() => IsDeleted = true;
}