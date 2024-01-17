namespace RealEstate.App.Operations.Fetch.Models
{
	public class HotelPensionFetchViewModel
	{
		public Guid basePostId { get; set; } = Guid.Empty;
		public Guid userID { get; set; } = Guid.Empty;
		public Guid addressId { get; set; } = Guid.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; } = 0.0f;
		public bool offerType { get; set; }

		public int roomCount { get; set; }
		public float roomSurface { get; set; } = 0.0f;
		public float usefulSurface { get; set; } = 0.0f;
	}
}
