using Project.Domain.Entities;
using Project.Domain.Entities.Categories;

namespace Project.Application.interfaces.Repository;

public interface ICategoryRepository : IRepository<Category, int>
{
}