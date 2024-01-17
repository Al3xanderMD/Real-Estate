namespace RealEstate.App.Operations.Create.Models
{
	public class PostCreateViewModel
	{
		public Guid basePostId { get; set; } = Guid.Empty;
		public string type { get; set; } = string.Empty;
	}
}
