using Project.Application.interfaces.Repository;
using Project.Domain.Entities;

namespace Project.Infrastructure.Persistence.Repositories;

public class CategoryRepository(PageDbContext context) : RepositoryBase<Category, int>(context), ICategoryRepository
{
}