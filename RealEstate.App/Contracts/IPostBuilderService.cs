using RealEstate.App.Operations.Create.Models;
using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Contracts
{
	public interface IPostBuilderService
	{
		bool SetOfferType(string offerType);
		ApartmentViewModel BuildApartmentPost(ApartmentViewModel apartmentPost, BasePostViewModel basePost, Dictionary<string,string> extraValues);
		CommercialViewModel BuildCommercialPost(CommercialViewModel commercialPost, BasePostViewModel basePost, Dictionary<string, string> extraValues, DateTime date);
		HotelPensionViewModel BuildHotelPensionPost(HotelPensionViewModel hotelPensionPost, BasePostViewModel basePost);
		HouseViewModel BuildHousePost(HouseViewModel housePost, BasePostViewModel basePost, Dictionary<string, string> extraValues);
		LotViewModel BuildLotPost(LotViewModel lotPost, BasePostViewModel basePost, Dictionary<string, string> extraValues);
	}
}
