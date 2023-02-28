using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class FactoryRepository : LocalizedRepositoryBase<Factory>
{
    public FactoryRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}