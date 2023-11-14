using MediatR;

namespace RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType
{
    public class CreateHouseTypeCommand : IRequest<CreateHouseTypeCommandResponse>
    {
        public string Type { get; set; } = default!;
    }
}
