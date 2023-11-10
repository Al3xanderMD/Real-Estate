using MediatR;

namespace RealEstate.Application.Features.Categories.Commands.CreateApartament
{
    public class CreateApartmentCommand : IRequest<CreateApartmentCommandResponse>
    {
        public string TitlePost { get; set; } = default!;
        public bool OfferType { get; set; } = default!;
        public string[] Image { get; set; } = default!;
        public double Price { get; set; } = default!;
        public string Descripion { get; set; } = default!;
        public int RoomCount { get; set; } = default!;
        public Guid PartitioningId { get; set; } = default!;
        public int Comfort { get; set; } = default!;
        public int Floor { get; set; } = default!;
        public double UsefulSurface { get; set; } = default!;
        public int BuildYear { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
        public Guid UserId { get; set; } = default!;

    }
}
