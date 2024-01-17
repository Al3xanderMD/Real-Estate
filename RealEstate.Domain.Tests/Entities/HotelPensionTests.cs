namespace RealEstate.Domain.Tests.Entities
{
	public class HotelPensionTests
	{
		[Fact]
		public void Create_ShouldCreateHotelPension_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.UserId.Should().Be(userId);
			result.Value.TitlePost.Should().Be(titlePost);
			result.Value.Price.Should().Be(price);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.OfferType.Should().Be(offerType);
			result.Value.Description.Should().Be(description);
			result.Value.UsefulSurface.Should().Be(usefulSurface);
			result.Value.RoomSurface.Should().Be(roomSurface);
			result.Value.RoomCount.Should().Be(roomCount);
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidTitle()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Title post must not be empty.");
		}

		[Fact]	
		public void Create_ShouldFail_WhenInvalidPrice()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 0;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Price must be larger than 0.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidAddressId()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.Empty;
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Address id must not be empty.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidOfferType()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Offer type must be true.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidDescription()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Description must not be empty.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidUsefulSurface()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 0;
			var roomSurface = 100;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful area must be larger than 0.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidRoomSurface()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 0;
			var roomCount = 100;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room surface must be larger than 0.");
		}

		[Fact]
		public void Create_ShouldFail_WhenInvalidRoomCount()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 0;

			// Act
			var result = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Room count must be larger than 0.");
		}

		[Fact]
		public void AttachBasePostId_ShouldUpdateBasePostId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
			hotelPension.AttachBasePostId(basePostId);
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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
			var newUsefulSurface = 200;

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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
			var newRoomSurface = 200;

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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
			var newRoomCount = 200;

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
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount).Value;
			var newRoomCount = 0;

			// Act
			hotelPension.AttachRoomCount(newRoomCount);

			// Assert
			hotelPension.RoomCount.Should().Be(roomCount);
		}

		[Fact]
		public void AttachUserId_ShouldUpdateUserId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "new test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachUserId(newUserId);

			// Assert
			hotelPension.Value.UserId.Should().Be(newUserId);
		}

		[Fact]
		public void AttachUserId_ShouldNotUpdateUserId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, titlePost, price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachUserId(newUserId);

			// Assert
			hotelPension.Value.UserId.Should().Be(userId);
		}

		[Fact]
		public void AttachTitlePost_ShouldUpdateTitlePost_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "new test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, "test title", price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachTitlePost(newTitlePost);

			// Assert
			hotelPension.Value.TitlePost.Should().Be(newTitlePost);
		}

		[Fact]
		public void AttachTitlePost_ShouldNotUpdateTitlePost_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, "test title", price, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachTitlePost(newTitlePost);

			// Assert
			hotelPension.Value.TitlePost.Should().Be("test title");
		}

		[Fact]
		public void AttachPrice_ShouldUpdatePrice_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 3000.12;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachPrice(newPrice);

			// Assert
			hotelPension.Value.Price.Should().Be(newPrice);
		}

		[Fact]
		public void AttachPrice_ShouldNotUpdatePrice_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 0;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;
			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, addressId, offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachPrice(newPrice);

			// Assert
			hotelPension.Value.Price.Should().Be(2000.12);
		}

		[Fact]
		public void AttachAddressId_ShouldUpdateAddressId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, Guid.NewGuid(), offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachAddressId(newAddressId);

			// Assert
			hotelPension.Value.AddressId.Should().Be(newAddressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotUpdateAddressId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.Empty;
			var offerType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, Guid.NewGuid(), offerType, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachAddressId(newAddressId);

			// Assert
			hotelPension.Value.AddressId.Should().NotBe(newAddressId);
		}

		[Fact]
		public void AttachOfferType_ShouldUpdateOfferType_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newOfferType = true;
			var description = "test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, Guid.NewGuid(), true, description, usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachOfferType(newOfferType);

			// Assert
			hotelPension.Value.OfferType.Should().Be(newOfferType);
		}

		[Fact]
		public void AttachDescription_ShouldUpdateDescription_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "new test description";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, Guid.NewGuid(), true, "test description", usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachDescription(newDescription);

			// Assert
			hotelPension.Value.Description.Should().Be(newDescription);
		}

		[Fact]
		public void AttachDescription_ShouldNotUpdateDescription_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "";
			var usefulSurface = 100;
			var roomSurface = 100;
			var roomCount = 100;

			var hotelPension = HotelPension.Create(userId, "test title", 2000.12, Guid.NewGuid(), true, "test description", usefulSurface, roomSurface, roomCount);

			// Act
			hotelPension.Value.AttachDescription(newDescription);

			// Assert
			hotelPension.Value.Description.Should().Be("test description");
		}
	
	}

}
