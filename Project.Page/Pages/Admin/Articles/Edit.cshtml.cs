using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Articles.GetArticle.GetById;
using Project.Application.UseCases.Articles.UpdataArticle;
using Project.Page.Contracts;
using Project.Page.Contracts.Article;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Articles;

public class Edit(IGetByIdUseCase getByIdUseCase, IUpdateArticleUseCase updateArticleUseCase) : PageModel
{
    public ArticleResponse ArticleResponse { get; set; }
    [BindProperty] public ArticleUpdateRequest ArticleUpdateRequest { get; set; }

    public async Task OnGetAsync(long id, CancellationToken cancellationToken)
    {
        var article = await getByIdUseCase.ExecuteAsync(id, cancellationToken);
        ArticleResponse = article.ToArticleResponse();
    }

    public async Task<IActionResult> OnPostAsync(long id, CancellationToken cancellationToken)
    {
        try
        {
            ArticleUpdateRequest.AuthorId = 1;
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