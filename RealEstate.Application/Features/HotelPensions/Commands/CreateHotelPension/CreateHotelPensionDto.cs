namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
	public class CreateHotelPensionDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public double UsefulSurface { get; set; }
        public double RoomSurface { get; set; }
        public int RoomCount { get; set; }
    }
}
