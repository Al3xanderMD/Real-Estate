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
	}
}
