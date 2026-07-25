using Project.Application.UseCases.Categories.GetCategory;

namespace Project.Application.UseCases.Articles.DeleteArticle;

public class DeleteArticleInputDto
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<GetAllCategoriesOutputDto> Categories { get; set; } = null!;
}