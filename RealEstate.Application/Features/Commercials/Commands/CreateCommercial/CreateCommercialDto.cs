using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
    public class CreateCommercialDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public BasePost BasePost { get; set; } = null!;
        public Guid CommercialSpecificId { get; set; }
        public CommercialSpecific CommercialSpecific { get; set; } = null!;
        public double UsefulSurface { get; set; }
        public DateTime? Disponibility { get; set; }
    }
}
