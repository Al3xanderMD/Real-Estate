using RealEstate.App.Contracts;
using RealEstate.App.Operations.Create.Models;
using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Services
{
	public class PostBuilderService : IPostBuilderService
	{
		public ApartmentViewModel BuildApartmentPost(ApartmentViewModel apartmentPost, BasePostViewModel basePost, Dictionary<string, string> extraValues)
		{
			apartmentPost.price = basePost.price;
			apartmentPost.titlePost = basePost.title;
			apartmentPost.description = basePost.description;
			apartmentPost.offerType = SetOfferType(basePost.offerType);
			apartmentPost.addressId = basePost.addressId;
			apartmentPost.partitioningId = extraValues[basePost.extraFieldValue];

			return apartmentPost;
		}

		public CommercialViewModel BuildCommercialPost(CommercialViewModel commercialPost, BasePostViewModel basePost, Dictionary<string, string> extraValues, DateTime? date)
		{
			commercialPost.price = basePost.price;
			commercialPost.titlePost = basePost.title;
			commercialPost.description = basePost.description;
			commercialPost.offerType = SetOfferType(basePost.offerType);
			commercialPost.addressId = basePost.addressId;
			commercialPost.commercialSpecificId = extraValues[basePost.extraFieldValue];
			commercialPost.disponibility = (DateTime)date;

			return commercialPost;
		}
		
		public HotelPensionViewModel BuildHotelPensionPost(HotelPensionViewModel hotelPensionPost, BasePostViewModel basePost)
		{
			hotelPensionPost.price = basePost.price;
			hotelPensionPost.titlePost = basePost.title;
			hotelPensionPost.description = basePost.description;
			hotelPensionPost.offerType = SetOfferType(basePost.offerType);
			hotelPensionPost.addressId = basePost.addressId;

			return hotelPensionPost;
		}

		public HouseViewModel BuildHousePost(HouseViewModel housePost, BasePostViewModel basePost, Dictionary<string, string> extraValues)
		{
			housePost.price = basePost.price;
			housePost.titlePost = basePost.title;
			housePost.description = basePost.description;
			housePost.offerType = SetOfferType(basePost.offerType);
			housePost.addressId = basePost.addressId;
			housePost.houseTypeId = extraValues[basePost.extraFieldValue];
			return housePost;
		}

		public LotViewModel BuildLotPost(LotViewModel lotPost, BasePostViewModel basePost, Dictionary<string, string> extraValues)
		{
			lotPost.price = basePost.price;
			lotPost.titlePost = basePost.title;
			lotPost.description = basePost.description;
			lotPost.offerType = SetOfferType(basePost.offerType);
			lotPost.addressId = basePost.addressId;
			lotPost.lotClassificationId = extraValues[basePost.extraFieldValue];

			return lotPost;
		}


		public bool SetOfferType(string offerType)
		{
			if (offerType == "Renting")
			{
				return false;
			}
			else if (offerType == "Selling")
			{
				return true;
			}
			else
			{
				Console.WriteLine("Invalid offer type");
				return true; //defaulting to true
			}
		}
	}
}
