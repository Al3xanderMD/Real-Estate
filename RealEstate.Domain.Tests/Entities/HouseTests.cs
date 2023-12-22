namespace RealEstate.Domain.Tests.Entities
{
	public class HouseTests
	{
		[Fact]
		public void CreateHouse_WithValidArguments_ShouldCreateHouse()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.UserId.Should().Be(userId);
			result.Value.TitlePost.Should().Be(titlePost);
			result.Value.Price.Should().Be(price);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.OfferType.Should().Be(offerType);
			result.Value.Description.Should().Be(description);
			result.Value.RoomCount.Should().Be(roomCount);
			result.Value.FloorCount.Should().Be(floorCount);
			result.Value.UsefulSurface.Should().Be(usefulSurface);
			result.Value.LotArea.Should().Be(lotArea);
			result.Value.BuildYear.Should().Be(buildYear);
			result.Value.HouseTypeId.Should().Be(houseTypeId);
		}

		[Fact]
		public void CreateHouse_WithInvalidTitlePost_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'TitlePost' must not be empty");
		}

		[Fact]
		public void CreateHouse_WithInvalidPrice_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = -1;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Price' must be greater than 0");
		}

		[Fact]
		public void CreateHouse_WithInvalidAddressId_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.Empty;
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'AddressId' must not be empty");
		}

		[Fact]
		public void CreateHouse_WithInvalidRoomCount_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = -1;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'RoomCount' must be greater than 0");
		}

		[Fact]
		public void CreateHouse_WithInvalidFloorCount_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = -1;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'FloorCount' must be greater than 0");
		}

		[Fact]
		public void CreateHouse_WithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = -1;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'UsefulSurface' must be greater than 0");
		}

		[Fact]
		public void CreateHouse_WithInvalidLotArea_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = -1;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'LotArea' must be greater than 0");
		}

		[Fact]
		public void CreateHouse_WithInvalidBuildYear_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 1899;
			var houseTypeId = Guid.NewGuid();

			// Act
			var result = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("The Build Year must be after 1900 and before " + DateTime.Now.Year + 1);
		}

		[Fact]
		public void AttachRoomCount_ShouldUpdateRoomCount_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newRoomCount = 3;

			// Act
			house.AttachRoomCount(newRoomCount);

			// Assert
			house.RoomCount.Should().Be(newRoomCount);
		}

		[Fact]
		public void AttachHouseTypeId_ShouldUpdateHouseTypeId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newHouseTypeId = Guid.NewGuid();

			// Act
			house.AttachHouseTypeId(newHouseTypeId);

			// Assert
			house.HouseTypeId.Should().Be(newHouseTypeId);
		}

		[Fact]
		public void AttachHouseTypeId_ShouldNotUpdateHouseTypeId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
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
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var lotArea = 100;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId).Value;
			var newComfort = 3;

			// Act
			house.AttachComfort(newComfort);

			// Assert
			house.Comfort.Should().Be(newComfort);
		}

		[Fact]
		public void AttachFloorCount_ShouldUpdateFloorCount_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var offerType = false;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var floorCount = 2;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newFloorCount = 3;

			// Act
			house.AttachFloorCount(newFloorCount);

			// Assert
			house.FloorCount.Should().Be(newFloorCount);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldUpdateUsefulSurface_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var usefulSurface = 100;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newUsefulSurface = 200;

			// Act
			house.AttachUsefulSurface(newUsefulSurface);

			// Assert
			house.UsefulSurface.Should().Be(newUsefulSurface);
		}

		[Fact]
		public void AttachLotArea_ShouldUpdateLotArea_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var lotArea = 100;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newLotArea = 200;

			// Act
			house.AttachLotArea(newLotArea);

			// Assert
			house.LotArea.Should().Be(newLotArea);
		}

		[Fact]
		public void AttachBuildYear_ShouldUpdateBuildYear_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var houseTypeId = Guid.NewGuid();
			var buildYear = 2000;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;
			var newBuildYear = 2001;

			// Act
			house.AttachBuildYear(newBuildYear);

			// Assert
			house.BuildYear.Should().Be(newBuildYear);
		}

		[Fact]
		public void AttachUserId_ShouldUpdateUserId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "new test user id";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;

			// Act
			house.AttachUserId(newUserId);

			// Assert
			house.UserId.Should().Be(newUserId);
		}

		[Fact]
		public void AttachUserId_ShouldNotUpdateUserId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var floorCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea, buildYear,houseTypeId).Value;

			// Act
			house.AttachUserId(newUserId);

			// Assert
			house.UserId.Should().Be(userId);
		}

		[Fact]
		public void AttachTitlePost_ShouldUpdateTitlePost_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "new test title post";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var floorCount = 2;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea,buildYear, houseTypeId).Value;

			// Act
			house.AttachTitlePost(newTitlePost);

			// Assert
			house.TitlePost.Should().Be(newTitlePost);
		}

		[Fact]	
		public void AttachTitlePost_ShouldNotUpdateTitlePost_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var floorCount = 2;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea,buildYear, houseTypeId).Value;

			// Act
			house.AttachTitlePost(newTitlePost);

			// Assert
			house.TitlePost.Should().Be(titlePost);
		}

		[Fact]
		public void AttachPrice_ShouldUpdatePrice_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 2000;
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var floorCount = 2;
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea,buildYear, houseTypeId).Value;

			// Act
			house.AttachPrice(newPrice);

			// Assert
			house.Price.Should().Be(newPrice);
		}

		[Fact]
		public void AttachPrice_ShouldNotUpdatePrice_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = -1;
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var lotArea = 100;
			var buildYear = 2000;
			var floorCount = 2;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea,buildYear, houseTypeId).Value;

			// Act
			house.AttachPrice(newPrice);

			// Assert
			house.Price.Should().Be(price);
		}

		[Fact]
		public void AttachAddressId_ShouldUpdateAddressId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.NewGuid();
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var roomCount = 2;
			var usefulSurface = 100;
			var floorCount = 2;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface, lotArea,buildYear, houseTypeId).Value;

			// Act
			house.AttachAddressId(newAddressId);

			// Assert
			house.AddressId.Should().Be(newAddressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotUpdateAddressId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.Empty;
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var usefulSurface = 100;
			var roomCount = 2;
			var floorCount = 2;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface,lotArea, buildYear, houseTypeId).Value;

			// Act
			house.AttachAddressId(newAddressId);

			// Assert
			house.AddressId.Should().Be(addressId);
		}

		[Fact]
		public void AttachOfferType_ShouldUpdateOfferType_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newOfferType = false;
			var titlePost = "test title post";
			var offerType = true;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var description = "test description";
			var usefulSurface = 100;
			var roomCount = 2;
			var floorCount = 2;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface,lotArea, buildYear, houseTypeId).Value;

			// Act
			house.AttachOfferType(newOfferType);

			// Assert
			house.OfferType.Should().Be(newOfferType);
		}

		[Fact]
		public void AttachDescription_ShouldUpdateDescription_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "new test description";
			var titlePost = "test title post";
			var offerType = false;
			var price = 1000;
			var addressId = Guid.NewGuid();
			var usefulSurface = 100;
			var roomCount = 2;
			var floorCount = 2;
			var lotArea = 100;
			var buildYear = 2000;
			var houseTypeId = Guid.NewGuid();
			var description = "test description";
			var house = House.Create(userId, titlePost, price, addressId, offerType, description, roomCount, floorCount, usefulSurface,lotArea, buildYear, houseTypeId).Value;

			// Act
			house.AttachDescription(newDescription);

			// Assert
			house.Description.Should().Be(newDescription);
		}

        [Fact]
        public void House_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            HouseType houseType = new HouseType("Test Home");
            int roomCount = 3;
            int floorCount = 2;
            double usefulSurface = 150.0;
            double lotArea = 200.0;
            int buildYear = 2020;
            Guid houseTypeId = Guid.NewGuid();
            string userId = "testUser";
            string titlePost = "Test House Post";
            double price = 300000.0;
            Guid addressId = Guid.NewGuid();
            bool offerType = true;
            string description = "This is a test house post.";

            // Act
            var house = new House(houseType, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId, userId, titlePost, price, addressId, offerType, description);

            // Assert
            house.Should().NotBeNull();
            house.HouseType.Should().Be(houseType);
            house.RoomCount.Should().Be(roomCount);
            house.FloorCount.Should().Be(floorCount);
            house.UsefulSurface.Should().Be(usefulSurface);
            house.LotArea.Should().Be(lotArea);
            house.BuildYear.Should().Be(buildYear);
            house.HouseTypeId.Should().Be(houseTypeId);
            house.UserId.Should().Be(userId);
            house.TitlePost.Should().Be(titlePost);
            house.Price.Should().Be(price);
            house.AddressId.Should().Be(addressId);
            house.OfferType.Should().Be(offerType);
            house.Description.Should().Be(description);
        }

    }
}
