using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Lots.Queries.GetAll
{
    public class GetAllLotsQueryHandler : IRequestHandler<GetAllLotsQuery, GetAllLotsResponse>
    {
        private readonly ILotRepository repository;

        public GetAllLotsQueryHandler(ILotRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllLotsResponse> Handle(GetAllLotsQuery request, CancellationToken cancellationToken)
        {
            GetAllLotsResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Lots = result.Value.Select(lot => new LotDto
                {
                    BasePostId = lot.BasePostId,
                    UserId = lot.UserId,
                    TitlePost = lot.TitlePost,
                    Price = lot.Price,
                    AddressId = lot.AddressId,
                    OfferType = lot.OfferType,
                    Description = lot.Description,
                    LotArea = lot.LotArea,
                    StreetFrontage = lot.StreetFrontage,
                    LotClassificationId = lot.LotClassificationId
                }).ToList();
            }
            return response;
        }
    }
}
