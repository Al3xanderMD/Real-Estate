
using RealEstate.Application.Features.Apartments.Commands.UpdateApartament;
using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Apartments.Commands.UpdateApartment
{
	public class UpdateApartmentCommandResponse : BaseResponse
	{
		public UpdateApartmentCommandResponse() : base()
		{
		}
		public UpdateApartmentDto Apartment { get; set; }

	}
}


