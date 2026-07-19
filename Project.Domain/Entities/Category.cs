namespace Project.Domain.Entities;

public class Category
{
    private Category()
    {
    }

    private readonly List<ArticleCategory> _articleCategories = [];
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public bool IsDeleted { get; private set; } = false;

    public ICollection<ArticleCategory>? ArticlesCategories => _articleCategories.AsReadOnly();

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}