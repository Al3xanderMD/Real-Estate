using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Apartments.Commands.DeleteApartment
{
    public class DeleteApartmentHandler : IRequestHandler<DeleteApartment, DeleteApartmentResponse>
    {
        private readonly IApartmentRepository repository;

        public DeleteApartmentHandler(IApartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteApartmentResponse> Handle(DeleteApartment request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteApartmentResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteApartmentResponse
            {
                Success = true
            };
        }
    }
}
