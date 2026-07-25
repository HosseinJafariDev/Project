using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Articles.DeleteArticle;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Page.Contracts;
using Project.Page.Contracts.Article;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Articles;

public class Index(IGetAllArticleUseCase allArticleUseCase, IDeleteArticleUseCase deleteArticleUseCase) : PageModel
{
    public List<ArticleResponse> Articles { get; set; } = new List<ArticleResponse>();
    [BindProperty] public ArticleDeleteRequest ArticleDeleteRequest { get; set; }

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        var article = await allArticleUseCase.ExecuteAsync(cancellationToken);
        Articles = article.ToArticleResponse();
    }

    public async Task<IActionResult> OnPostDeleteAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine(ArticleDeleteRequest.CreatedAt);
        var article = ArticleDeleteRequest.ToDeleteArticleInputDto();
        var result = await deleteArticleUseCase.ExecuteAsync(article, cancellationToken);
        return new JsonResult(result);
    }
}