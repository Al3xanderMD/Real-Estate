using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Addresses.Commands.DeleteAddres
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddress, DeleteAddressResponse>
    {
        private readonly IAddressRepository repository;

        public DeleteAddressHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteAddressResponse> Handle(DeleteAddress request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if(!result.IsSuccess)
            {
                return new DeleteAddressResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            } 
            return new DeleteAddressResponse
            {
                Success = true
            };
        }
    }
}
