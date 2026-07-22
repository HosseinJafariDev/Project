namespace Project.Application.UseCases.Categories.EditCategory;

public interface IEditCategoryUseCase
{
    Task ExecuteAsync(EditCategoryInputDto input, CancellationToken cancellationToken);
}