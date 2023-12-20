using MediatR;

namespace RealEstate.Application.Features.Commercials.Commands.DeleteCommercial
{
    public class DeleteCommercial : IRequest<DeleteCommercialResponse>
    {
        public Guid BasePostId { get; set; }
    }
}
