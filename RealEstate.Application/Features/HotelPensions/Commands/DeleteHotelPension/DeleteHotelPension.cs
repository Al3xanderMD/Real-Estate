using MediatR;

namespace RealEstate.Application.Features.HotelPensions.Commands.DeleteHotelPension
{
    public class DeleteHotelPension : IRequest<DeleteHotelPensionResponse>
    {
        public Guid Id { get; set; }
    }
}
