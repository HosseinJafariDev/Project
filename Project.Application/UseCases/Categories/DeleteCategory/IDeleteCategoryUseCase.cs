namespace Project.Application.UseCases.Categories.DeleteCategory;

public interface IDeleteCategoryUseCase
{
    Task<bool> ExecuteAsync(DeleteCategoryInputDto input, CancellationToken cancellationToken);
}