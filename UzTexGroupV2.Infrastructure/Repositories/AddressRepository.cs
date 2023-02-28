using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class AddressRepository : RepositoryBase<Address>
{
    public AddressRepository(UzTexGroupDbContext context) : base(context)
    {
    }
}