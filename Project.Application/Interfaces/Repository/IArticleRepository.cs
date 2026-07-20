using Project.Domain.Entities;
using Project.Domain.Entities.Articles;

namespace Project.Application.interfaces.Repository;

public interface IArticleRepository : IRepository<Article, long>
{
}