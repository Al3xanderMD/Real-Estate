namespace RealEstate.App.Models
{
	public class PostModel
	{
		public string PropertyType { get; set; }
		public bool OfferType { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string RoomCount { get; set; }
		public string Floor { get; set; }
		public string FloorCount { get; set; }
		public int BuildYear { get; set; }
		public float Area { get; set; }
		public float UsefulSurface { get; set; }
		public string LotType { get; set; }
		public string Address { get; set; }
		public float StreetFrontage { get; set; }
		public float LotArea { get; set; }
		public float Price { get; set; }
		public List<string> ImageUrl { get; set; }
		public string MainImageUrl { get; set; }
		public string ContactEmail { get; set; }
		public string ContactPhone { get; set; }
		public string ContactName { get; set; }
		public string UserId { get; set; }

		public PostModel()
		{
			ImageUrl = new List<string>();
			MainImageUrl = "";
			BuildYear = DateTime.Now.Year;
			Title = "Title";
			Description = "Description";
			Price = 0;
			RoomCount = "1";
		}
	}
}