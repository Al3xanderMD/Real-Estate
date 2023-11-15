using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
    public class CreateLotClassificationDTO
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
    }
}
