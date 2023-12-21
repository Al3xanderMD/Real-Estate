using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HotelPensions.Queries.GetAll
{
    public class GetAllHotelPensionsQueryHandler : IRequestHandler<GetAllHotelPensionsQuery, GetAllHotelPensionsResponse>
    {
        private readonly IHotelPensionRepository repository;

        public GetAllHotelPensionsQueryHandler(IHotelPensionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllHotelPensionsResponse> Handle(GetAllHotelPensionsQuery request, CancellationToken cancellationToken)
        {
            GetAllHotelPensionsResponse response = new();
            var result = await repository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.HotelPensions = result.Value.Select(hotelPension => new HotelPensionDto
                {
                    BasePostId = hotelPension.BasePostId,
                    UserId = hotelPension.UserId,
                    TitlePost = hotelPension.TitlePost,
                    Price = hotelPension.Price,
                    AddressId = hotelPension.AddressId,
                    OfferType = hotelPension.OfferType,
                    Description = hotelPension.Description,
                    UsefulSurface = hotelPension.UsefulSurface,
                    RoomSurface = hotelPension.RoomSurface,
                    RoomCount = hotelPension.RoomCount
                }).ToList();
            }
            return response;
        }
    }
}
