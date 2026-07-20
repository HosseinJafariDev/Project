using Project.Domain.Entities;

namespace Project.Application.interfaces.Repository;

public interface IArticleRepository : IRepository<Article, long>
{
}