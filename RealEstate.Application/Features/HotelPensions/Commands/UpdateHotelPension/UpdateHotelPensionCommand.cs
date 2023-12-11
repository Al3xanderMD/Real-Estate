using MediatR;

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionCommand: IRequest<UpdateHotelPensionCommandResponse>
	{
		public Guid Id { get; set; }
		public Guid BasePostId { get; set; }
		public double UsefulSurface { get; set; } = default!;
		public double RoomSurface { get; set; } = default!;
		public int RoomCount { get; set; } = default!;
	}
}
