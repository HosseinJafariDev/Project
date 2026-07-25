namespace Project.Application.UseCases.Articles.GetArticle;

public interface IGetAllArticleUseCase
{
    Task<List<GetAllArticleOutputDto>> ExecuteAsync(CancellationToken cancellationToken);
}