using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Articles.Mappers;

namespace Project.Application.UseCases.Articles.GetArticle;

public class GetAllArticleUseCase(IArticleRepository articleRepository) : IGetAllArticleUseCase
{
    public async Task<List<GetAllArticleOutputDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var articles = await articleRepository.GetAllAsync(cancellationToken);
        return articles.MapToListGetAllArticleOutputDto();
    }
}