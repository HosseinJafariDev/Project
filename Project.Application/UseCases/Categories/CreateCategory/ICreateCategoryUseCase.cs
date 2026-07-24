namespace Project.Application.UseCases.Categories.CreateCategory;

public interface ICreateCategoryUseCase
{
    Task<bool> ExecuteAsync(CreateCategoryInputDto input, CancellationToken cancellationToken);
}