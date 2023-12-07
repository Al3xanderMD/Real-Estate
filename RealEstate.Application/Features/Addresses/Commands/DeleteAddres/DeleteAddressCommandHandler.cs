using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Addresses.Commands.DeleteAddres
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public DeleteAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if(!result.IsSuccess)
            {
                return new DeleteAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            } 
            return new DeleteAddressCommandResponse
            {
                Success = true
            };
        }
    }
}
