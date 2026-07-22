using Microsoft.EntityFrameworkCore;
using Project.Application.interfaces.Repository;
using Project.Domain.Entities.Categories;

namespace Project.Infrastructure.Persistence.Repositories;

public class CategoryRepository(PageDbContext context) : RepositoryBase<Category, int>(context), ICategoryRepository
{
    public override async Task<IReadOnlyList<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.Where(x => x.IsDeleted != true).AsNoTracking().ToListAsync(cancellationToken);
    }
}