using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, AddressDto>
    {
        private readonly IAddressRepository repository;

        public GetByIdAddressQueryHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddressDto> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await repository.FindByIdAsync(request.Id);

            if(address.IsSuccess)
            {
                return new AddressDto
                {
                    Id = address.Value.Id,
                    Url = address.Value.Url,
                    AddressName = address.Value.AddressName
                };
            }
            return new AddressDto();
        }
    }
}
