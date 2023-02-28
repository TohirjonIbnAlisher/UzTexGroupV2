using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public abstract class UnitOfWorkBase
{
    protected readonly UzTexGroupDbContext uzTexGroupDbContext;
    public UnitOfWorkBase(UzTexGroupDbContext uzTexGroupDbContext)
    {
        this.uzTexGroupDbContext = uzTexGroupDbContext;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await uzTexGroupDbContext.SaveChangesAsync();
    }
}