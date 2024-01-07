namespace RealEstate.App.Operations.Create.Models
{
	public class HouseViewModel
	{
		public string userId { get; set; } = string.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; }
		public string addressId { get; set; } = string.Empty;
		public bool offerType { get; set; }
		public int roomCount { get; set; }
		public int floorCount { get; set; }
		public int usefulSurface { get; set; }
		public float lotArea { get; set; }
		public int buildYear { get; set; }
		public string houseTypeId { get; set; } = string.Empty;
	}
}
