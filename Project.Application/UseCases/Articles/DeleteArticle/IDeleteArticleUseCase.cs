namespace Project.Application.UseCases.Articles.DeleteArticle;

public interface IDeleteArticleUseCase
{
    Task<bool> ExecuteAsync(DeleteArticleInputDto articleInputDto, CancellationToken cancellationToken);
}