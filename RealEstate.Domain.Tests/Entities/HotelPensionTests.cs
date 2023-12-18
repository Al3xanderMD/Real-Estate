namespace RealEstate.Domain.Tests.Entities
{
	public class HotelPensionTests
	{
		[Fact]
		public void CreateHotelPension_WithValidArguments_ShouldCreateHotelPension()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;

			// Act
			var result = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.BasePostId.Should().Be(basePostId);
			result.Value.UsefulSurface.Should().Be(400);
			result.Value.RoomSurface.Should().Be(345);
			result.Value.RoomCount.Should().Be(5);
		}

		[Fact]
		public void CreateHotelPension_WithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 0;
			var roomSurface = 345;
			var roomCount = 5;

			// Act
			var result = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful area must be larger than 0.");
		}

		[Fact]
		public void CreateHotelPension_WithInvalidRoomSurface_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 0;
			var roomCount = 5;

			// Act
			var result = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room surface must be larger than 0.");
		}

		[Fact]
		public void CreateHotelPension_WithInvalidRoomCount_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 0;

			// Act
			var result = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room count must be larger than 0.");
		}

		[Fact]
		public void AttachBasePostId_ShouldUpdateBasePostId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newBasePostId = Guid.NewGuid();

			// Act
			hotelPension.AttachBasePostId(newBasePostId);

			// Assert
			hotelPension.BasePostId.Should().Be(newBasePostId);
		}

		[Fact]
		public void AttachBasePostId_ShouldNotUpdateBasePostId_WhenNull()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newBasePostId = Guid.Empty;

			// Act
			hotelPension.AttachBasePostId(newBasePostId);

			// Assert
			hotelPension.BasePostId.Should().Be(basePostId);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldUpdateUsefulSurface_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newUsefulSurface = 500;

			// Act
			hotelPension.AttachUsefulSurface(newUsefulSurface);

			// Assert
			hotelPension.UsefulSurface.Should().Be(newUsefulSurface);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldNotUpdateUsefulSurface_WhenInvalid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newUsefulSurface = 0;

			// Act
			hotelPension.AttachUsefulSurface(newUsefulSurface);

			// Assert
			hotelPension.UsefulSurface.Should().Be(usefulSurface);
		}

		[Fact]
		public void AttachRoomSurface_ShouldUpdateRoomSurface_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newRoomSurface = 500;

			// Act
			hotelPension.AttachRoomSurface(newRoomSurface);

			// Assert
			hotelPension.RoomSurface.Should().Be(newRoomSurface);
		}

		[Fact]
		public void AttachRoomSurface_ShouldNotUpdateRoomSurface_WhenInvalid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newRoomSurface = 0;

			// Act
			hotelPension.AttachRoomSurface(newRoomSurface);

			// Assert
			hotelPension.RoomSurface.Should().Be(roomSurface);
		}

		[Fact]
		public void AttachRoomCount_ShouldUpdateRoomCount_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newRoomCount = 6;

			// Act
			hotelPension.AttachRoomCount(newRoomCount);

			// Assert
			hotelPension.RoomCount.Should().Be(newRoomCount);
		}

		[Fact]
		public void AttachRoomCount_ShouldNotUpdateRoomCount_WhenInvalid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var usefulSurface = 400;
			var roomSurface = 345;
			var roomCount = 5;
			var hotelPension = HotelPension.Create(basePostId, usefulSurface, roomSurface, roomCount).Value;
			var newRoomCount = 0;

			// Act
			hotelPension.AttachRoomCount(newRoomCount);

			// Assert
			hotelPension.RoomCount.Should().Be(roomCount);
		}
	}
}
