using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LotClassificationRepository : BaseRepository<LotClassification>, ILotClassificationRepository
    {
        public LotClassificationRepository(RealEstateContext context) : base(context)
        {
        }
    }
}
