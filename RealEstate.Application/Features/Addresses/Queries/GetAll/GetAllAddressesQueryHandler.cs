using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, GetAllAddressesResponse>
    {
        private readonly IAddressRepository repository;

        public GetAllAddressesQueryHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllAddressesResponse> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            GetAllAddressesResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Addresses = result.Value.Select(address => new AddressDto
                {
                    Id = address.Id,
                    Url = address.Url,
                    AddressName = address.AddressName
                }).ToList();
            }
            return response;
        }
    }
}
