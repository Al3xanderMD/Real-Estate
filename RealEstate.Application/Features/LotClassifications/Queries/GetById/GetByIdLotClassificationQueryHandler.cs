using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.LotClassifications.Queries.GetById
{
    public class GetByIdLotClassificationQueryHandler : IRequestHandler<GetByIdLotClassificationQuery, LotClassificationDto>
    {
        private readonly ILotClassificationRepository repository;
        public GetByIdLotClassificationQueryHandler(ILotClassificationRepository repository)
        {
            this.repository = repository;
        }
        public async Task<LotClassificationDto> Handle(GetByIdLotClassificationQuery request, CancellationToken cancellationToken)
        {
            var lotClassification = await repository.FindByIdAsync(request.Id);
            if(lotClassification.IsSuccess)
            {
                return new LotClassificationDto
                {
                    Id = lotClassification.Value.Id,
                    Type = lotClassification.Value.Type
                };
            }
            return new LotClassificationDto();
        }
    }
}
