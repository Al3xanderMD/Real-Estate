namespace RealEstate.App.Operations.Fetch.Models
{
	public class HouseFetchViewModel
	{
		public Guid basePostId { get; set; } = Guid.Empty;
		public Guid userID { get; set; } = Guid.Empty;
		public Guid addressId { get; set; } = Guid.Empty;
		public Guid houseTypeId { get; set; } = Guid.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; } = 0.0f;
		public bool offerType { get; set; }

		public int roomCount { get; set; }
		public int floorCount { get; set; }
		public float usefulSurface { get; set; } = 0.0f;
		public int buildYear { get; set; }
		public float lotArea { get; set; } = 0.0f;

	}
}
