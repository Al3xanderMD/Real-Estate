namespace RealEstate.Application.Features.Addresses.Queries
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = default!;
        public string AddressName { get; set; } = default!;
    }
}
