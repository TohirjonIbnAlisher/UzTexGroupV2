using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class JobRepository : LocalizedRepositoryBase<Job>
{
    public JobRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}