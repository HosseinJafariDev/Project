using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Articles.GetArticle;
using Project.Page.Contracts;
using Project.Page.Mappers;

namespace Project.Page.Pages.Admin.Articles;

public class Index(IGetAllArticleUseCase allArticleUseCase) : PageModel
{
    public List<ArticleResponse> Articles { get; set; } = new List<ArticleResponse>();

    public async void OnGetAsync(CancellationToken cancellationToken)
    {
        var article = await allArticleUseCase.ExecuteAsync(cancellationToken);
        Articles = article.ToArticleResponse();
    }
}