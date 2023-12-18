namespace RealEstate.Domain.Entities.Tests
{
	public class ApartmentTests
	{
		[Fact]
		public void Create_ApartmentWithValidData_ShouldSucceed()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(2, 3, 1, 75.5, 2000, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.RoomCount.Should().Be(2);
			result.Value.Comfort.Should().Be(3);
			result.Value.Floor.Should().Be(1);
			result.Value.UsefulSurface.Should().Be(75.5);
			result.Value.BuildYear.Should().Be(2000);
			result.Value.BasePostId.Should().Be(basePostId);
			result.Value.PartitioningId.Should().Be(partitioningId);
		}

		[Fact]
		public void Create_ApartmentWithInvalidRoomCount_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(0, 3, 1, 75.5, 2000, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room count must be larger than 0.");
		}

		[Fact]
		public void Create_ApartmentWithInvalidComfort_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(2, 0, 1, 75.5, 2000, basePostId, partitioningId);
			var result2 = Apartment.Create(2, 5, 1, 75.5, 2000, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Comfort must be larger than 0 and less than 5.");
			result2.IsSuccess.Should().BeFalse();
			result2.Error.Should().Be("Comfort must be larger than 0 and less than 5.");
		}

		[Fact]
		public void Create_ApartmentWithInvalidFloor_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(2, 3, 0, 75.5, 2000, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room count must be larger than 0.");
		}

		[Fact]
		public void Create_ApartmentWithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(2, 3, 1, 0, 2000, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful surface must be larger than 0.");
		}

		[Fact]
		public void Create_ApartmentWithInvalidBuildYear_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();

			// Act
			var result = Apartment.Create(2, 3, 1, 75.5, 1809, basePostId, partitioningId);
			var result2 = Apartment.Create(2, 3, 1, 75.5, 2071, basePostId, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			var str = "The Build Year must be after 1900 and before " + (DateTime.Now.Year + 1);
			result.Error.Should().Be(str);
			result2.IsSuccess.Should().BeFalse();
			result2.Error.Should().Be(str);
		}

		[Fact]
		public void AttachPartitioning_ShouldSetPartitioning()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var partitioningId = Guid.NewGuid();
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, basePostId, partitioningId).Value;
			var partitioning = Guid.NewGuid();

			// Act
			apartment.AttachPartitioningId(partitioning);

			// Assert
			apartment.PartitioningId.Should().Be(partitioning);
		}

		[Fact]
		public void AttachRoomCount_WithValidData_ShouldSetRoomCount()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachRoomCount(3);

			// Assert
			apartment.RoomCount.Should().Be(3);
		}

		[Fact]
		public void AttachRoomCount_WithInvalidData_ShouldNotSetRoomCount()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachRoomCount(-3);

			// Assert
			apartment.RoomCount.Should().Be(2);
		}

		[Fact]
		public void AttachComfort_WithValidData_ShouldSetComfort()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachComfort(4);

			// Assert
			apartment.Comfort.Should().Be(4);
		}

		[Fact]
		public void AttachComfort_WithInvalidData_ShouldNotSetComfort()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachComfort(5);

			// Assert
			apartment.Comfort.Should().Be(3);
		}

		[Fact]
		public void AttachFloor_WithValidData_ShouldSetFloor()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachFloor(2);

			// Assert
			apartment.Floor.Should().Be(2);
		}

		[Fact]
		public void AttachFloor_WithInvalidData_ShouldNotSetFloor()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachFloor(-2);

			// Assert
			apartment.Floor.Should().Be(1);
		}

		[Fact]
		public void AttachUsefulSurface_WithValidData_ShouldSetUsefulSurface()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachUsefulSurface(80.5);

			// Assert
			apartment.UsefulSurface.Should().Be(80.5);
		}

		[Fact]
		public void AttachUsefulSurface_WithInvalidData_ShouldNotSetUsefulSurface()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachUsefulSurface(-80.5);

			// Assert
			apartment.UsefulSurface.Should().Be(75.5);
		}

		[Fact]
		public void AttachBuildYear_WithValidData_ShouldSetBuildYear()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2000, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachBuildYear(2010);

			// Assert
			apartment.BuildYear.Should().Be(2010);
		}

		[Fact]
		public void AttachBuildYear_WithInvalidData_ShouldNotSetBuildYear()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2010, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachBuildYear(1800);

			// Assert
			apartment.BuildYear.Should().Be(2010);
		}

		[Fact]
		public void AttachBasePostId_WithValidData_ShouldSetBasePostId()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2010, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			var newBasePostId = Guid.NewGuid();
			apartment.AttachBasePostId(newBasePostId);

			// Assert
			apartment.BasePostId.Should().Be(newBasePostId);
		}

		[Fact]
		public void AttachBasePostId_WithInvalidData_ShouldNotSetBasePostId()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2010, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachBasePostId(Guid.Empty);

			// Assert
			apartment.BasePostId.Should().NotBe(Guid.Empty);
		}

		[Fact]
		public void AttachPartitioningId_WithValidData_ShouldSetPartitioningId()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2010, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			var newPartitioningId = Guid.NewGuid();
			apartment.AttachPartitioningId(newPartitioningId);

			// Assert
			apartment.PartitioningId.Should().Be(newPartitioningId);
		}

		[Fact]
		public void AttachPartitioningId_WithInvalidData_ShouldNotSetPartitioningId()
		{
			// Arrange
			var apartment = Apartment.Create(2, 3, 1, 75.5, 2010, Guid.NewGuid(), Guid.NewGuid()).Value;

			// Act
			apartment.AttachPartitioningId(Guid.Empty);

			// Assert
			apartment.PartitioningId.Should().NotBe(Guid.Empty);
		}



	}
}
