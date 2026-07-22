namespace Project.Application.UseCases.Categories.GetCategory;

public interface IGetAllCategoriesUseCase
{
    Task<List<GetAllCategoriesOutputDto>> ExecuteAsync(CancellationToken cancellationToken);
}