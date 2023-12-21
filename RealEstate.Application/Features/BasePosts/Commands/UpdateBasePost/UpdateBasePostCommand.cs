using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.BasePosts.Commands.UpdateBasePost
{
	public class UpdateBasePostCommand: IRequest<UpdateBasePostCommandResponse>
	{
		public Guid Id { get; set; }
		public string? UserId { get; set; }
		public string TitlePost { get; set; } = default!;
		public List<string> Images { get; set; } = default!;
		public bool OfferType { get; set; } = default!;
		public double Price { get; set; } = default!;
		public Guid AddressId { get; set; }
		public string Descripion { get; set; } = default!;
	}
}
