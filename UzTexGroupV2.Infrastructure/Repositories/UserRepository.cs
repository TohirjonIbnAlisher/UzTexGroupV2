using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}