using RealEstate.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
    public class CreateLotCommandResponse : BaseResponse
    {
        public CreateLotCommandResponse() : base()
        {

        }

        public CreateLotDTO Lot { get; set; }
    }
}
