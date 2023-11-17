using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.DeleteApartment
{
    public class DeleteApartment : IRequest<DeleteApartmentResponse>
    {
        public Guid Id { get; set; }
    }
}
