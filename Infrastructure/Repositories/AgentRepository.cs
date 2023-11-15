using RealEstate.Domain.Entities;
using RealEstate.Application.Persistence;

namespace Infrastructure.Repositories
{
    public class AgentRepository : BaseRepository<Agent>, IAgentRepository
    {
        public AgentRepository(RealEstateContext context) : base(context)
        {
        }
    }
}
