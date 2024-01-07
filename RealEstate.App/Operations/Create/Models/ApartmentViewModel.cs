namespace RealEstate.App.Operations.Create.Models
{
	public class ApartmentViewModel
	{
		public string userId { get; set; } = string.Empty;
		public string titlePost { get; set; } = string.Empty;
		public float price { get; set; }
		public int buildYear { get; set; }
		public int floor { get; set; }
		public int comfort { get; set; }
		public int roomCount { get; set; }
		public bool offerType { get; set; }
		public float usefulSurface { get; set; }
		public string addressId { get; set; } = string.Empty;
		public string partitioningId { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
	}
}
