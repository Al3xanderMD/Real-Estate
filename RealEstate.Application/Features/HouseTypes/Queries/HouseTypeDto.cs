using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.HouseTypes.Queries
{
    public class HouseTypeDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = default!;
    }
}
