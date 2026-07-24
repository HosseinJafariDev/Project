using Project.Application.Interfaces.Persistence;
using Project.Application.interfaces.Repository;
using Project.Application.UseCases.Categories.Mappers;

namespace Project.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICreateCategoryUseCase
{
    public async Task<bool> ExecuteAsync(CreateCategoryInputDto input,
        CancellationToken cancellationToken)
    {
        categoryRepository.Add(input.ToCategory());
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}