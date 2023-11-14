using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentCommandResponse : BaseResponse
    {
        public CreateApartmentCommandResponse() : base()
        {
        }

        public CreateApartmentDTO Apartment { get; set; }
    }
}
