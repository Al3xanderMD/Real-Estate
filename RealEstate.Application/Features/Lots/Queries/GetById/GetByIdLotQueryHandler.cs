using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Lots.Queries.GetById
{
    public class GetByIdLotQueryHandler : IRequestHandler<GetByIdLotQuery, LotDto>
    {
        private readonly ILotRepository repository;

        public GetByIdLotQueryHandler(ILotRepository repository)
        {
            this.repository = repository;
        }

        public async Task<LotDto> Handle(GetByIdLotQuery request, CancellationToken cancellationToken)
        {
            var lot = await repository.FindByIdAsync(request.Id);

            if(lot.IsSuccess)
            {
                return new LotDto
                {
                    BasePostId = lot.Value.BasePostId,
                    UserId = lot.Value.UserId,
                    TitlePost = lot.Value.TitlePost,
                    Price = lot.Value.Price,
                    AddressId = lot.Value.AddressId,
                    OfferType = lot.Value.OfferType,
                    Description = lot.Value.Description,
                    LotArea = lot.Value.LotArea,
                    StreetFrontage = lot.Value.StreetFrontage,
                    LotClassificationId = lot.Value.LotClassificationId
                };
            }
            return new LotDto();
        }
    }
}
