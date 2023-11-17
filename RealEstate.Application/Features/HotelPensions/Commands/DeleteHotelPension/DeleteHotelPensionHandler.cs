using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HotelPensions.Commands.DeleteHotelPension
{
    public class DeleteHotelPensionHandler : IRequestHandler<DeleteHotelPension, DeleteHotelPensionResponse>
    {
        private readonly IHotelPensionRepository repository;

        public DeleteHotelPensionHandler(IHotelPensionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteHotelPensionResponse> Handle(DeleteHotelPension request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if(!result.IsSuccess)
            {
                return new DeleteHotelPensionResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteHotelPensionResponse
            {
                Success = true
            };
        }
    }
}
