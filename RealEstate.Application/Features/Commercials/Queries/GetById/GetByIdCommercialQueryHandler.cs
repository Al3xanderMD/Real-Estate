using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Commercials.Queries.GetById
{
    public class GetByIdCommercialQueryHandler : IRequestHandler<GetByIdCommercialQuery, CommercialDto>
    {
        private readonly ICommercialRepository repository;

        public GetByIdCommercialQueryHandler(ICommercialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CommercialDto> Handle(GetByIdCommercialQuery request, CancellationToken cancellationToken)
        {
            var commercial = await repository.FindByIdAsync(request.Id);

            if (commercial.IsSuccess)
            {
                return new CommercialDto
                {
                    BasePostId = commercial.Value.BasePostId,
                    UserId = commercial.Value.UserId,
                    TitlePost = commercial.Value.TitlePost,
                    Price = commercial.Value.Price,
                    AddressId = commercial.Value.AddressId,
                    OfferType = commercial.Value.OfferType,
                    Description = commercial.Value.Description,
                    CommercialSpecificId = commercial.Value.CommercialSpecificId,
                    UsefulSurface = commercial.Value.UsefulSurface,
                    Disponibility = commercial.Value.Disponibility
                };
            }
            return new CommercialDto();
        }
    }
}
