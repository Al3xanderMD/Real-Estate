using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
	public class ApiResponsePartitionings
	{
		public List<ApartmentPartitioningViewModel> partitionings { get; set; } = new List<ApartmentPartitioningViewModel>();
	}
}
