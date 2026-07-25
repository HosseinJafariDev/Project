using Project.Application.UseCases.Categories.GetCategory;

namespace Project.Application.UseCases.Articles.CreateArticle;

public class CreateArticleInputDto
{
    public long AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public List<GetAllCategoriesOutputDto> Categories { get; set; } = null!;
}