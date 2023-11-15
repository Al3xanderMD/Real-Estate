using RealEstate.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
    public class CreateLotClassificationCommandResponse : BaseResponse
    {
        public CreateLotClassificationCommandResponse() : base()
        {
        }

        public CreateLotClassificationDTO LotClassification { get; set; }
    }
}
