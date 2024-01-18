using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Favourites.Commands.DeleteFavourites
{
    public class DeleteFavouritesCommandHandler : IRequestHandler<DeleteFavouritesCommand, DeleteFavouritesCommandResponse>
    {
        private readonly IFavouritesRepository repository;
        public DeleteFavouritesCommandHandler(IFavouritesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteFavouritesCommandResponse> Handle(DeleteFavouritesCommand request, CancellationToken cancellationToken)
        {

            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteFavouritesCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }

            return new DeleteFavouritesCommandResponse
            {
                Success = true
            };
        }
    }
}
