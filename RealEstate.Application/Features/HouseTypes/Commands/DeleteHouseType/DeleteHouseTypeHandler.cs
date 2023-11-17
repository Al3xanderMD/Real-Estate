using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HouseTypes.Commands.DeleteHouseType
{
    public class DeleteHouseTypeHandler : IRequestHandler<DeleteHouseType, DeleteHouseTypeResponse>
    {
        private readonly IHouseTypeRepository repository;

        public DeleteHouseTypeHandler(IHouseTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteHouseTypeResponse> Handle(DeleteHouseType request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteHouseTypeResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteHouseTypeResponse
            {
                Success = true
            };
        }
    }
}