namespace RealEstate.App.Models
{
	public class PostAddressViewModel
	{
		public Guid id { get; set; } = Guid.Empty;
		public string url { get; set; } = string.Empty;
		public string addressName { get; set; } = string.Empty;
		public Guid createdBy { get; set; } = Guid.Empty;
		public DateTime createdDate { get; set; } = DateTime.Now;
		public Guid? lastModifiedBy { get; set; } = Guid.Empty;
		public DateTime? lastModifiedDate { get; set; } = DateTime.Now;
	}
}
