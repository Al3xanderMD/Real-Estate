namespace RealEstate.App.Operations.Fetch.Models
{
	public class ApartmentFetchViewModel
	{
		public Guid basePostId { get; set; }
		public Guid userId { get; set; }
		public Guid partitioningId { get; set; }
		public Guid addressId { get; set; }
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; } = 0.0f;
		public int roomCount { get; set; }
		public int comfort { get; set; }
		public int floor { get; set; }
		public float usefulSurface { get; set; } = 0.0f;
		public int buildYear { get; set; }
		public bool offerType { get; set; }
	}
}
