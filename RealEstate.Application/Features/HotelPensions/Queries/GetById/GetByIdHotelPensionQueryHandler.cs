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
                    Id = hotelPension.Value.Id,
                    BasePostId = hotelPension.Value.BasePostId,
                    UsefulSurface = hotelPension.Value.UsefulSurface,
                    RoomSurface = hotelPension.Value.RoomSurface,
                    RoomCount = hotelPension.Value.RoomCount
                };
            }
            return new HotelPensionDto();
        }
    }
}
