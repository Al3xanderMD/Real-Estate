namespace RealEstate.Domain.Tests.Entities
{
	public class HouseTests
	{
		[Fact]
		public void CreateHouse_WithValidArguments_ShouldCreateHouse()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.BasePostId.Should().Be(basePostId);
			result.Value.RoomCount.Should().Be(roomCount);
			result.Value.FloorCount.Should().Be(floorCount);
			result.Value.UsefulSurface.Should().Be(usefulSurface);
			result.Value.LotArea.Should().Be(lotArea);
			result.Value.BuildYear.Should().Be(buildYear);
			result.Value.HouseTypeId.Should().Be(houseTypeId);
		}

		[Fact]
		public void CreateHouse_WithInvalidRoomCount_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 0;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room count must be larger than 0.");
		}

		[Fact]
		public void CreateHouse_WithInvalidFloorCount_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 0;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Floor count must be larger than 0.");
		}

		[Fact]
		public void CreateHouse_WithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 0;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful surface must be larger than 0.");
		}

		[Fact]
		public void CreateHouse_WithInvalidLotArea_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 0;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Lot area must be larger than 0.");
		}

		[Fact]
		public void CreateHouse_WithInvalidBuildYear_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 1899;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("The Build Year must be after 1900 and before " + DateTime.Now.Year + 1);
		}


		[Fact]
		public void AttachBasePostId_ShouldUpdateBasePostId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newBasePostId = Guid.NewGuid();

			// Act
			house.AttachBasePostId(newBasePostId);

			// Assert
			house.BasePostId.Should().Be(newBasePostId);
		}

		[Fact]
		public void AttachBasePostId_ShouldNotUpdateBasePostId_WhenEmpty()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newBasePostId = Guid.Empty;

			// Act
			house.AttachBasePostId(newBasePostId);

			// Assert
			house.BasePostId.Should().Be(basePostId);
		}

		[Fact]
		public void AttachRoomCount_ShouldUpdateRoomCount_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newRoomCount = 6;

			// Act
			house.AttachRoomCount(newRoomCount);

			// Assert
			house.RoomCount.Should().Be(newRoomCount);
		}

		[Fact]
		public void AttachHouseTypeId_ShouldUpdateHouseTypeId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newHouseTypeId = Guid.NewGuid();

			// Act
			house.AttachHouseTypeId(newHouseTypeId);

			// Assert
			house.HouseTypeId.Should().Be(newHouseTypeId);
		}

		[Fact]
		public void AttachHouseTypeId_ShouldNotUpdateHouseTypeId_WhenEmpty()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newHouseTypeId = Guid.Empty;

			// Act
			house.AttachHouseTypeId(newHouseTypeId);

			// Assert
			house.HouseTypeId.Should().Be(houseTypeId);
		}

		[Fact]
		public void AttachComfort_ShouldUpdateComfort_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newComfort = 6;

			// Act
			house.AttachComfort(newComfort);

			// Assert
			house.Comfort.Should().Be(newComfort);
		}

		[Fact]
		public void AttachFloorCount_ShouldUpdateFloorCount_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newFloorCount = 6;

			// Act
			house.AttachFloorCount(newFloorCount);

			// Assert
			house.FloorCount.Should().Be(newFloorCount);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldUpdateUsefulSurface_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newUsefulSurface = 500;

			// Act
			house.AttachUsefulSurface(newUsefulSurface);

			// Assert
			house.UsefulSurface.Should().Be(newUsefulSurface);
		}

		[Fact]
		public void AttachlotArea_ShouldUpdateLotArea_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newLotArea = 600;

			// Act
			house.AttachLotArea(newLotArea);

			// Assert
			house.LotArea.Should().Be(newLotArea);
		}

		[Fact]
		public void AttachBuildYear_ShouldUpdateBuildYear_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var roomCount = 5;
			var floorCount = 3;
			var usefulSurface = 400;
			var lotArea = 500;
			var buildYear = 2001;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newBuildYear = 2002;

			// Act
			house.AttachBuildYear(newBuildYear);

			// Assert
			house.BuildYear.Should().Be(newBuildYear);
		}
	}
}
