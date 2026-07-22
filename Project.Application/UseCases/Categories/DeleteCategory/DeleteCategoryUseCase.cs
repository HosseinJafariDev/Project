using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Categories.Mappers;

namespace Project.Application.UseCases.Categories.DeleteCategory;

public class DeleteCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : IDeleteCategoryUseCase
{
    public async Task<bool> ExecuteAsync(DeleteCategoryInputDto input, CancellationToken cancellationToken)
    {
        var category = input.ToCategory();
        category.Delete();
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}