using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
	public class ApiResponseCommercialSpecifics
	{
		public List<CommercialSpecificViewModel> commercialSpecifics { get; set; } = new List<CommercialSpecificViewModel>();
	}
}
