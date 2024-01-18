namespace RealEstate.App.Operations.Fetch.Models
{
	public class PostViewModel
	{
		public int id { get; set; }
		public Guid basePostId { get; set; } = Guid.Empty;
		public string type { get; set; } = string.Empty;
	}
}
