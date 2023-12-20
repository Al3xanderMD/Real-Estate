using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommand: IRequest<UpdateLotCommandResponse>
	{
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
        public bool OfferType { get; set; } = default!;
        public string Description { get; set; } = default!;
		public double LotArea { get; set; } = default!;
		public double StreetFrontage { get; set; } = default!;
        public Guid LotClassificationId { get; set; }

    }
}
