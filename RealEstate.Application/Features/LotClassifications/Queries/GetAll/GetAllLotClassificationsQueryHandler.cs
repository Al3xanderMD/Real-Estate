using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.LotClassifications.Queries.GetAll
{
    public class GetAllLotClassificationsQueryHandler : IRequestHandler<GetAllLotClassificationsQuery, GetAllLotClassificationsResponse>
    {
        private readonly ILotClassificationRepository repository;
        public GetAllLotClassificationsQueryHandler(ILotClassificationRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetAllLotClassificationsResponse> Handle(GetAllLotClassificationsQuery request, CancellationToken cancellationToken)
        {
            GetAllLotClassificationsResponse response = new();
            var result = await repository.GetAllAsync();
            if(result.IsSuccess)
            {
                response.LotClassifications = result.Value.Select(lotClassification => new LotClassificationDto
                {
                    Id = lotClassification.Id,
                    Type = lotClassification.Type
                }).ToList();
            }
            return response;
        }
    }
}
