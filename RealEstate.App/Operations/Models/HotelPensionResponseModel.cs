using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Models
{
	public class HotelPensionResponseModel
	{
		public HotelPensionFetchViewModel hotelPension { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }
		public List<string> ValidationErrors { get; set; }
	}
}
