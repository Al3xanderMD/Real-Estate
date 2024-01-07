using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
	public class ApiResponseHouseType
	{
		public List<HouseTypeViewModel> houseTypes { get; set; } = new List<HouseTypeViewModel>();
	}
}
