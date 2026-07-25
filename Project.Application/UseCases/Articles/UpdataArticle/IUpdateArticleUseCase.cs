namespace Project.Application.UseCases.Articles.UpdataArticle;

public interface IUpdateArticleUseCase
{
    Task<bool> ExecuteAsync(UpdateArticleInputDto input, CancellationToken cancellationToken);
}