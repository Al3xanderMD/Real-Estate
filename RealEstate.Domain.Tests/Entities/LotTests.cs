namespace RealEstate.Domain.Tests.Entities
{
	public class LotTests
	{
		[Fact]
		public void CreateLot_WithValidArguments_ShouldCreateLot()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.UserId.Should().Be(userId);
			result.Value.TitlePost.Should().Be(titlePost);
			result.Value.Price.Should().Be(price);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.OfferType.Should().Be(offerType);
			result.Value.Description.Should().Be(description);
			result.Value.LotArea.Should().Be(lotArea);
			result.Value.StreetFrontage.Should().Be(streetFrontage);
			result.Value.LotClassificationId.Should().Be(lotClassificationId);
		}

		[Fact]
		public void CreateLot_WithInvalidTitlePost_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'TitlePost' must not be empty");
		}

		[Fact]
		public void CreateLot_WithInvalidPrice_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 0;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Price' must be greater than 0");
		}

		[Fact]
		public void CreateLot_WithInvalidAddressId_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.Empty;
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'AddressId' must not be empty");
		}

		[Fact]
		public void CreateLot_WithInvalidLotArea_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 0;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'LotArea' must be greater than 0");
		}

		[Fact]
		public void CreateLot_WithInvalidStreetFrontage_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 0;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'StreetFrontage' must be greater than 0");
		}

		[Fact]
		public void CreateLot_WithInvalidDescription_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();

			// Act
			var result = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Description' must not be empty");
		}

		[Fact]
		public void AttachLotClassificationId_ShouldUpdateLotClassificationId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotClassificationId = Guid.NewGuid();

			// Act
			lot.AttachLotClassificationId(newLotClassificationId);

			// Assert
			lot.LotClassificationId.Should().Be(newLotClassificationId);
		}

		[Fact]
		public void AttachLotArea_ShouldUpdateLotArea_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotArea = 200;

			// Act
			lot.AttachLotArea(newLotArea);

			// Assert
			lot.LotArea.Should().Be(newLotArea);
		}

		[Fact]
		public void AttachStreetFrontage_ShouldUpdateStreetFrontage_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;
			var newStreetFrontage = 200;

			// Act
			lot.AttachStreetFrontage(newStreetFrontage);

			// Assert
			lot.StreetFrontage.Should().Be(newStreetFrontage);
		}

		[Fact]
		public void AttachUserId_ShouldUpdateUserId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "new user id";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachUserId(newUserId);

			// Assert
			lot.UserId.Should().Be(newUserId);
		}

		[Fact]
		public void AttachUserId_ShouldNotUpdateUserId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newUserId = "";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachUserId(newUserId);

			// Assert
			lot.UserId.Should().Be(userId);
		}

		[Fact]
		public void AttachTitlePost_ShouldUpdateTitlePost_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "new title post";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachTitlePost(newTitlePost);

			// Assert
			lot.TitlePost.Should().Be(newTitlePost);
		}

		[Fact]
		public void AttachTitlePost_ShouldNotUpdateTitlePost_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "";
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachTitlePost(newTitlePost);

			// Assert
			lot.TitlePost.Should().Be(titlePost);
		}

		[Fact]
		public void AttachPrice_ShouldUpdatePrice_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 2000;
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachPrice(newPrice);

			// Assert
			lot.Price.Should().Be(newPrice);
		}

		[Fact]
		public void AttachPrice_ShouldNotUpdatePrice_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 0;
			var titlePost = "test title post";
			var price = 1000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachPrice(newPrice);

			// Assert
			lot.Price.Should().Be(price);
		}

		[Fact]
		public void AttachAddressId_ShouldUpdateAddressId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.NewGuid();
			var titlePost = "test title post";
			var price = 2000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachAddressId(newAddressId);

			// Assert
			lot.AddressId.Should().Be(newAddressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotUpdateAddressId_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.Empty;
			var titlePost = "test title post";
			var price = 2000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachAddressId(newAddressId);

			// Assert
			lot.AddressId.Should().Be(addressId);
		}

		[Fact]
		public void AttachOfferType_ShouldUpdateOfferType_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newOfferType = false;
			var titlePost = "test title post";
			var price = 2000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId).Value;

			// Act
			lot.AttachOfferType(newOfferType);

			// Assert
			lot.OfferType.Should().Be(newOfferType);
		}

		[Fact]
		public void AttachDescription_ShouldUpdateDescription_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "new description";
			var titlePost = "test title post";
			var price = 2000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Act
			lot.Value.AttachDescription(newDescription);

			// Assert
			lot.Value.Description.Should().Be(newDescription);
		}

		[Fact]
		public void AttachDescription_ShouldNotUpdateDescription_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "";
			var titlePost = "test title post";
			var price = 2000;
			var addressId = Guid.NewGuid();
			var offerType = true;
			var description = "test description";
			var lotArea = 200;
			var streetFrontage = 200;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(userId, titlePost, price, addressId, offerType, description, lotArea, streetFrontage, lotClassificationId);

			// Act
			lot.Value.AttachDescription(newDescription);

			// Assert
			lot.Value.Description.Should().Be(description);
		}

        [Fact]
        public void Lot_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            LotClassification lotClassification = new LotClassification("Test Type");
            double lotArea = 300.0;
            double streetFrontage = 20.0;
            Guid lotClassificationId = Guid.NewGuid();
            string userId = "testUser";
            string titlePost = "Test Lot Post";
            double price = 50000.0;
            Guid addressId = Guid.NewGuid();
            bool offerType = true;
            string description = "This is a test lot post.";

            // Act
            var lot = new Lot(lotClassification, lotArea, streetFrontage, lotClassificationId, userId, titlePost, price, addressId, offerType, description);

            // Assert
            lot.Should().NotBeNull();
            lot.LotClassification.Should().Be(lotClassification);
            lot.LotArea.Should().Be(lotArea);
            lot.StreetFrontage.Should().Be(streetFrontage);
            lot.LotClassificationId.Should().Be(lotClassificationId);
            lot.UserId.Should().Be(userId);
            lot.TitlePost.Should().Be(titlePost);
            lot.Price.Should().Be(price);
            lot.AddressId.Should().Be(addressId);
            lot.OfferType.Should().Be(offerType);
            lot.Description.Should().Be(description);
        }
    }
}
