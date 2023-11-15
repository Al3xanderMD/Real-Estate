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
                    Id = lot.Id,
                    BasePostId = lot.BasePostId,
                    LotArea = lot.LotArea,
                    StreetFrontage = lot.StreetFrontage,
                    LotClassificationId = lot.LotClassificationId
                }).ToList();
            }
            return response;
        }
    }
}
