using MediatR;

namespace RealEstate.Application.Features.HouseTypes.Commands.DeleteHouseType
{
    public class DeleteHouseType : IRequest<DeleteHouseTypeResponse>
    {
        public Guid Id { get; set; }
    }
}
