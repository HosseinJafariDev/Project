namespace Project.Domain.Entities;

public class Category
{
    private Category()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ArticleCategory>? ArticlesCategories { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}