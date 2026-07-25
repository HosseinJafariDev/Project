namespace Project.Application.UseCases.Articles.GetArticle.GetById;

public interface IGetByIdUseCase
{
    Task<GetByIdOutputDto> ExecuteAsync(long id, CancellationToken cancellationToken);
}