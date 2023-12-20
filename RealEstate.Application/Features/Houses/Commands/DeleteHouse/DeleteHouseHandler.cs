using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Houses.Commands.DeleteHouse
{
    public class DeleteHouseHandler : IRequestHandler<DeleteHouse, DeleteHouseResponse>
    {
        private readonly IHouseRepository repository;

        public DeleteHouseHandler(IHouseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteHouseResponse> Handle(DeleteHouse request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.BasePostId);

            if(!result.IsSuccess)
            {
                return new DeleteHouseResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteHouseResponse
            {
                Success = true
            };
        }
    }
}
