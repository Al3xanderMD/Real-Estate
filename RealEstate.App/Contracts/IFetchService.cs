using RealEstate.App.Operations.Fetch.Models;
using RealEstate.App.Operations.Fetch.Response;

namespace RealEstate.App.Contracts
{
    public interface IFetchService
	{
		Task<List<LotClassificationViewModel>> FetchLotClassificationsAsync();
		Task<List<CommercialCategoryViewModel>> FetchCommercialCategoriesAsync();
		Task<List<ApartmentPartitioningViewModel>> FetchApartmentPartitionsAsync();
		Task<List<HouseTypeViewModel>> FetchHouseTypesAsync();
		Task<List<CommercialSpecificViewModel>> FetchCommercialSpecificsAsync();
		Task<PostResponseViewModel> FetchPostAsync(int id);
		Task<ApartmentFetchViewModel> FetchApartmentAsync(Guid id);
		Task<HouseFetchViewModel> FetchHouseAsync(Guid id);
		Task<CommercialFetchViewModel> FetchCommercialAsync(Guid id);
		Task<LotFetchViewModel> FetchLotAsync(Guid id);
		Task<HotelPensionFetchViewModel> FetchHotelPensionAsync(Guid id);

		////
		
		Task<List<FavouriteFetchViewModel>> FetchFavouritesUserAsync(Guid userId);
		Task<List<FavouriteFetchViewModel>> FetchUserFavouritePostsAsync(Guid userId);
		Task<PostResponseViewModel> FetchPostByBasePostIdAsync(Guid id);
		Task<List<PostResponseViewModel>> FetchPostsByUserIdAsync(Guid userId);

	}
}
