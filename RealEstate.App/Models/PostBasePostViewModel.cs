using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Models
{
	public class PostBasePostViewModel
	{
		public Guid basePostId { get; set; } = Guid.Empty;
		public Guid userId { get; set; } = Guid.Empty;
		public Guid addressId { get; set; } = Guid.Empty;
		public string titlePost { get; set; } = string.Empty;
		public List<string> images { get; set; } = new List<string>();
		public bool offerType { get; set; }
		public float price { get; set; }
		public string description { get; set; } = string.Empty;
		public string createdBy { get; set; } = string.Empty;
		public DateTime createdDate { get; set; } = DateTime.Now;
		public string lastModifiedBy { get; set; } = string.Empty;
		public DateTime? lastModifiedDate { get; set; } = DateTime.Now;
		public PostAddressViewModel addressModel { get; set; } = new PostAddressViewModel();
	}
}
