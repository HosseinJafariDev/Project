using Project.Domain.Entities;

namespace Project.Application.interfaces.Repository;

public interface ICategoryRepository : IRepository<Category, int>
{
}