namespace RealEstate.App.Operations.Fetch.Models
{
	public class BasePostViewModel
	{
		public string title { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; }
		public string addressId { get; set; } = string.Empty;
		public string offerType { get; set; }
		public string postType { get; set; } = string.Empty;
		public string extraFieldValue { get; set; } = string.Empty;
	}
}
