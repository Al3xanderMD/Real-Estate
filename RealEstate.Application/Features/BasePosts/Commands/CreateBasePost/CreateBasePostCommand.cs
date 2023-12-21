using MediatR;

namespace RealEstate.Application.Features.Categories.Commands.CreateBasePost
{
    public class CreateBasePostCommand : IRequest<CreateBasePostCommandResponse>
    {
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
        public bool OfferType { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
