using Project.Application.Interfaces.Persistence;

namespace Project.Infrastructure.Persistence;

public class UnitOfWork(PageDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}