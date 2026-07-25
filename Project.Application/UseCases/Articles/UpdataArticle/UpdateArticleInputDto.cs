using Project.Application.UseCases.Categories.GetCategory;

namespace Project.Application.UseCases.Articles.UpdataArticle;

public class UpdateArticleInputDto
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime CreateAt { get; set; }
    public List<GetAllCategoriesOutputDto> Categories { get; set; } = null!;
}