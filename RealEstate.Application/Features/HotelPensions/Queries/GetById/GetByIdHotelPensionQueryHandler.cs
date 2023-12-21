using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HotelPensions.Queries.GetById
{
    public class GetByIdHotelPensionQueryHandler : IRequestHandler<GetByIdHotelPensionQuery, HotelPensionDto>
    {
        private readonly IHotelPensionRepository repository;

        public GetByIdHotelPensionQueryHandler(IHotelPensionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<HotelPensionDto> Handle(GetByIdHotelPensionQuery request, CancellationToken cancellationToken)
        {
            var hotelPension = await repository.FindByIdAsync(request.Id);

            if (hotelPension.IsSuccess)
            {
                return new HotelPensionDto
                {
                    BasePostId = hotelPension.Value.BasePostId,
                    UserId = hotelPension.Value.UserId,
                    TitlePost = hotelPension.Value.TitlePost,
                    Price = hotelPension.Value.Price,
                    AddressId = hotelPension.Value.AddressId,
                    OfferType = hotelPension.Value.OfferType,
                    Description = hotelPension.Value.Description,
                    UsefulSurface = hotelPension.Value.UsefulSurface,
                    RoomSurface = hotelPension.Value.RoomSurface,
                    RoomCount = hotelPension.Value.RoomCount
                };
            }
            return new HotelPensionDto();
        }
    }
}
