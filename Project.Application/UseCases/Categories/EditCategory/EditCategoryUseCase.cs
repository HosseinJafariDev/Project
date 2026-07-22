using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Categories.Mappers;

namespace Project.Application.UseCases.Categories.EditCategory;

public class EditCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IEditCategoryUseCase
{
    public async Task ExecuteAsync(EditCategoryInputDto input, CancellationToken cancellationToken)
    {
        var category = input.ToCategory();
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}