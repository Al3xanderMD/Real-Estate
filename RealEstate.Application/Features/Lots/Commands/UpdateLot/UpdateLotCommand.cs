using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommand: IRequest<UpdateLotCommandResponse>
	{
		public Guid Id { get; set; }
		public Guid BasePostId { get; set; }
		public BasePost BasePost { get; set; } = default!;
		public Guid LotClassificationId { get; set; }
		public LotClassification LotClassification { get; set; } = default!;
		public double LotArea { get; set; } = default!;
		public double StreetFrontage { get; set; } = default!;
		
	}
}
