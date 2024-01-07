namespace RealEstate.App.Operations.Create.Models
{
	public class LotViewModel
	{
		public string userId { get; set; } = string.Empty;
		public string titlePost { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public float price { get; set; }
		public string addressId { get; set; } = string.Empty;
		public bool offerType { get; set; }
		public float lotArea { get; set; }
		public float streetFrontage { get; set; }
		public string lotClassificationId { get; set; } = string.Empty;
	}
}
