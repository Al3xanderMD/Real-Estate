using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentCommand : IRequest<CreateApartmentCommandResponse>
    {
        public int RoomCount { get; set; } = default!;
        public int Comfort { get; set; } = default!;
        public int Floor { get; set; } = default!;
        public double UsefulSurface { get; set; } = default!;
        public int BuildYear { get; set; } = default!;
        public Guid BasePostId { get; set; } = default!;
        public Guid PartitioningId { get; set; } = default!;
    }
}
