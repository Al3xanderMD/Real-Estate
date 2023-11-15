using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
    public class CreateHotelPensionCommand : IRequest<CreateHotelPensionCommandResponse>
    {
        public BasePost BasePost { get; set; } = default;
        public Guid BasePostId { get; set; } = default;
        public double UsefulSurface { get; set; } = default;
        public double RoomSurface { get; set; } = default!;
        public int RoomCount { get; set; } = default!;
    }
}
