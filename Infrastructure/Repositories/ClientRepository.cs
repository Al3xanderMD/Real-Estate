using RealEstate.Domain.Entities;
using RealEstate.Application.Persistence;

namespace Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(RealEstateContext context) : base(context)
        {
        }
    }
}
