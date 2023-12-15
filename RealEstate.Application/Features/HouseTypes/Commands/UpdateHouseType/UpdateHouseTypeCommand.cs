using MediatR;

namespace RealEstate.Application.Features.HouseTypes.Commands.UpdateHouseType
{
	public class UpdateHouseTypeCommand: IRequest<UpdateHouseTypeCommandResponse>
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = default!;
	}

}
