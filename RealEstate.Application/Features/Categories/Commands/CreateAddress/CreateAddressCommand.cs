using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.Categories.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandResponse>
    {
        public string Url { get; set; } = default;
        public string AddressName { get; set; } = default;
    }
}
