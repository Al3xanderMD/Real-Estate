using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.BasePosts.Commands.UpdateBasePost
{
	public class UpdateBasePostDto
	{
		public Guid UserId { get; set; }
		public Client? Client { get; set; }
		public string? TitlePost { get; set; }
		public List<string>? Images { get; set; }
		public bool? OfferType { get; set; }
		public double? Price { get; set; }
		public Guid AddressId { get; set; }
		public Address? Address { get; set; }
		public string? Descripion { get; set; }
	}
}
