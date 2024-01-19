using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
    public class FavouritesResponseViewModel
    {
        public List<FavouriteFetchViewModel> favourites { get; set; } = new List<FavouriteFetchViewModel>();
    }
}
