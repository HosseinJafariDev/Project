using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Articles.CreateArticle;
using Project.Application.UseCases.Categories.CreateCategory;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Page.Contracts;
using Project.Page.Contracts.Article;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Articles;

public class Create(IGetAllCategoriesUseCase getAllCategoriesUseCase, ICreateArticleUseCase createArticleUseCase)
    : PageModel
{
    public List<CategoryResponse> CategoriesList { get; set; } = new List<CategoryResponse>();
    [BindProperty] public ArticleCreateRequest CreateArticleRequest { get; set; }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);
        CategoriesList = categoriesDto.ToCategoriesResponse();
    }

    public async Task<JsonResult> OnPostAsync(CancellationToken cancellationToken)
    {
        var result =
            await createArticleUseCase.ExecuteAsync(CreateArticleRequest.ToArticleInputDto(), cancellationToken);
        return new JsonResult(result);
    }
}