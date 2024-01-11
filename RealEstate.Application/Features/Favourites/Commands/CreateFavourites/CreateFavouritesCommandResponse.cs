using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Favourites.Commands.CreateFavourites
{
    public class CreateFavouritesCommandResponse : BaseResponse
    {
        public CreateFavouritesCommandResponse() 
            : base()
        {
        }

        public CreateFavouritesDto Favourites {  get; set; }
    }
}
