using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
	public class ApiResponseLot
	{
		public List<LotClassificationViewModel> LotClassifications { get; set; } = new List<LotClassificationViewModel>();
	}
}
