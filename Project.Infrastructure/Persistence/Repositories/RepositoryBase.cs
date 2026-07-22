using Microsoft.EntityFrameworkCore;
using Project.Application.interfaces.Repository;

namespace Project.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<TEntity, TKey>(PageDbContext context)
    : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly PageDbContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        await DbSet.FindAsync(id, cancellationToken);
        return DbSet.Find(id);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await DbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }
}