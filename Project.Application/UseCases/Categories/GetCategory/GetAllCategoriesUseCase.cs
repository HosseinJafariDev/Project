using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Categories.Mappers;

namespace Project.Application.UseCases.Categories.GetCategory;

public class GetAllCategoriesUseCase(ICategoryRepository categoryRepository) : IGetAllCategoriesUseCase
{
    public async Task<List<GetAllCategoriesOutputDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync(cancellationToken);
        return categories.ToGetAllCategoriesOutputDtos();
    }
}