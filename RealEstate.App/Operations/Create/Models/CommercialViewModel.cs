namespace RealEstate.App.Operations.Create.Models
{
	public class CommercialViewModel
	{
		public string userId { get; set; } = string.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; }
		public string addressId { get; set; } = string.Empty;
		public bool offerType { get; set; }
		public string commercialSpecificId { get; set; } = string.Empty;
		public float usefulSurface { get; set; }
		public DateTime disponibility { get; set; } = DateTime.Today;
	}
}
