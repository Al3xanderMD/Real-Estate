namespace RealEstate.App.Operations.Create.Models
{
	public class HotelPensionViewModel
	{
		public string userId { get; set; } = string.Empty;
		public string titlePost { get; set; } = string.Empty;
		public float price { get; set; } = 0;
		public string description { get; set; } = string.Empty;
		public string addressId { get; set; } = string.Empty;
		public bool offerType { get; set; } = true;
		public float usefulSurface { get; set; }
		public float roomSurface { get; set; }
		public int roomCount { get; set; }
	}
}
