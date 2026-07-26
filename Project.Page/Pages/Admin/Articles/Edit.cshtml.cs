using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Articles.GetArticle.GetById;
using Project.Application.UseCases.Articles.UpdataArticle;
using Project.Application.UseCases.Categories.GetCategory;
using Project.Page.Contracts;
using Project.Page.Contracts.Article;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Articles;

[Authorize]
public class Edit(
    IGetByIdUseCase getByIdUseCase,
    IUpdateArticleUseCase updateArticleUseCase,
    IGetAllCategoriesUseCase getAllCategoriesUseCase) : PageModel
{
    public ArticleResponse ArticleResponse { get; set; }
    public List<CategoryResponse> CategoriesList { get; set; }
    [BindProperty] public ArticleUpdateRequest ArticleUpdateRequest { get; set; }

    public async Task OnGetAsync(long id, CancellationToken cancellationToken)
    {
        var categoriesDto = await getAllCategoriesUseCase.ExecuteAsync(cancellationToken);

        CategoriesList = categoriesDto.ToCategoriesResponse();

        var article = await getByIdUseCase.ExecuteAsync(id, cancellationToken);
        ArticleResponse = article.ToArticleResponse();
    }

    public async Task<IActionResult> OnPostAsync(long id, CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ArticleUpdateRequest.Id = id;
            var result =
                await updateArticleUseCase.ExecuteAsync(ArticleUpdateRequest.ToUpdateArticleInputDto(),
                    cancellationToken);
            return new JsonResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}