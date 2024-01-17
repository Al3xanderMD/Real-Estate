namespace RealEstate.App.Operations.Fetch.Models
{
	public class CommercialFetchViewModel
	{
		public Guid basePostId { get; set; } = Guid.Empty;
		public Guid userID { get; set; } = Guid.Empty;
		public Guid addressId { get; set; } = Guid.Empty;
		public Guid commercialSpecificId { get; set; } = Guid.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; } = 0.0f;
		public bool offerType { get; set; }
		DateTime disponibility { get; set; }
	}
}
