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
                    Id = lot.Value.Id,
                    BasePostId = lot.Value.BasePostId,
                    LotArea = lot.Value.LotArea,
                    StreetFrontage = lot.Value.StreetFrontage,
                    LotClassificationId = lot.Value.LotClassificationId
                };
            }
            return new LotDto();
        }
    }
}
