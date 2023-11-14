using MediatR;

namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommand : IRequest<CreateHouseCommandResponse>
    {
        public int RoomCount { get; set; } = default!;
        public int FloorCount { get; set; } = default!;
        public double UsefulSurface { get; set; } = default!;
        public double LotArea { get; set; } = default!;
        public int BuildYear { get; set; } = default!;
        public Guid BasePostId { get; set; } = default!;
        public Guid HouseTypeId { get; set; } = default!;
    }
}
