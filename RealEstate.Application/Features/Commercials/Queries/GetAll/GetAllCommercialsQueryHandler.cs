using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Commercials.Queries.GetAll
{
    public class GetAllCommercialsQueryHandler : IRequestHandler<GetAllCommercialsQuery, GetAllCommercialsResponse>
    {
        private readonly ICommercialRepository repository;

        public GetAllCommercialsQueryHandler(ICommercialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllCommercialsResponse> Handle(GetAllCommercialsQuery request, CancellationToken cancellationToken)
        {
            GetAllCommercialsResponse response = new();
            var result = await repository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.Commercials = result.Value.Select(commercial => new CommercialDto
                {
                    BasePostId = commercial.BasePostId,
                    UserId = commercial.UserId,
                    TitlePost = commercial.TitlePost,
                    Price = commercial.Price,
                    AddressId = commercial.AddressId,
                    OfferType = commercial.OfferType,
                    Description = commercial.Description,
                    CommercialSpecificId = commercial.CommercialSpecificId,
                    UsefulSurface = commercial.UsefulSurface,
                    Disponibility = commercial.Disponibility
                }).ToList();
            }
            return response;
        }
    }
}
