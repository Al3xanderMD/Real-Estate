using MediatR;

namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
	public class CreateLotCommand : IRequest<CreateLotCommandResponse>
    {
        public Guid Id { get; set; } = default!;
        public Guid BasePostId { get; set; } = default!;
        public double LotArea { get; set; } = default!;
        public double StreetFrontage { get; set; } = default!;
        public Guid LotClassificationId { get; set; } = default!;
    }
}
