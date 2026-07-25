using Microsoft.EntityFrameworkCore;
using Project.Application.interfaces.Repository;
using Project.Domain.Entities.Articles;

namespace Project.Infrastructure.Persistence.Repositories;

public class ArticleRepository(PageDbContext context) : RepositoryBase<Article, long>(context), IArticleRepository
{
    public override async Task<IReadOnlyList<Article>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.Include(x => x.ArticleCategories).ThenInclude(x => x.Category)
            .Where(x => x.IsDeleted == false).AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}