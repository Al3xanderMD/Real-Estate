namespace RealEstate.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressDto
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? AddressName { get; set; }
    }
}
