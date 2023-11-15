using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.Lots.CreateLot
{
    public class CreateLotDTO
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public double? LotArea { get; set; }
        public double? StreetFrontage { get; set; }
        public Guid LotClassificationId { get; set; }
    }
}
