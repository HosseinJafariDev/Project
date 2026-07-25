namespace Project.Application.UseCases.Articles.CreateArticle;

public interface ICreateArticleUseCase
{
    Task<bool> ExecuteAsync(CreateArticleInputDto articleInputDto, CancellationToken cancellationToken);
}