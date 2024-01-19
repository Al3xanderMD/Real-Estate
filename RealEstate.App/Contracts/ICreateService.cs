using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Contracts
{
	public interface ICreateService
	{
		Task CreateLot(LotViewModel model);
		Task CreateHouse(HouseViewModel model);
		Task CreateApartment(ApartmentViewModel model);
		Task CreateHotelPension(HotelPensionViewModel model);
		Task CreateCommercial(CommercialViewModel model);

		/////////////////////////

		Task CreatePartitioning();
		Task<string> CreateAddress(AddressViewModel model);
		Task CreateCommercialCategory();
		Task CreateCommercialSpecific();
		Task CreateHouseType();
		Task CreateLotClassification();

		/////////////////////////

		Task CreateFavouriteListing(FavouriteCreateViewModel model);
	}
}
