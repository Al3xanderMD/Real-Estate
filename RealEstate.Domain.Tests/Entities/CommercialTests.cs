namespace RealEstate.Domain.Tests.Entities
{
	public class CommercialTests
	{
		[Fact]
		public void CreateCommercial_WithValidArguments_ShouldCreateCommercial()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.BasePostId.Should().NotBe(Guid.Empty);
			result.Value.UserId.Should().Be(userId);
			result.Value.TitlePost.Should().Be(titlePost);
			result.Value.Price.Should().Be(price);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.OfferType.Should().Be(offerType);
			result.Value.Description.Should().Be(description);
			result.Value.CommercialSpecificId.Should().Be(commercialSpecificId);
			result.Value.UsefulSurface.Should().Be(usefulSurface);
			result.Value.Disponibility.Should().Be(disponibility);
		}

		[Fact]
		public void CreateCommercial_WithInvalidTitle_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'TitlePost' must not be empty");
		}

		[Fact]
		public void CreateCommercial_WithInvalidPrice_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 0;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Price' must be greater than 0");
		}

		[Fact]
		public void CreateCommercial_WithInvalidAddressId_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.Empty;
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'AddressId' must not be empty");
		}

		[Fact]
		public void CreateCommercial_WithInvalidCommercialSpecificId_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.Empty;
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'CommercialSpecificId' must not be empty");
		}

		[Fact]
		public void CreateCommercial_WithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 0;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful surface must be greater than 0");
		}

		[Fact]
		public void CreateCommercial_WithInvalidDisponibility_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(-1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Disponibility must be greater than today");
		}

		[Fact]
		public void CreateCommercial_WithInvalidDescription_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);

			// Act
			var result = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Description' must not be empty");
		}

		[Fact]
		public void AttachDisponibility_ShouldUpdateDisponibility_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newDisponibility = DateTime.Now.AddDays(2);

			// Act
			commercial.AttachDisponibility(newDisponibility);

			// Assert
			commercial.Disponibility.Should().Be(newDisponibility);
		}

		[Fact]
		public void AttachDisponibility_ShouldNotUpdateDisponibility_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newDisponibility = DateTime.Now.AddDays(-1);

			// Act
			commercial.AttachDisponibility(newDisponibility);

			// Assert
			commercial.Disponibility.Should().Be(disponibility);
		}

		[Fact]
		public void AttachCommercialSpecificId_ShouldUpdateCommercialSpecificId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newCommercialSpecificId = Guid.NewGuid();

			// Act
			commercial.AttachCommercialSpecificId(newCommercialSpecificId);

			// Assert
			commercial.CommercialSpecificId.Should().Be(newCommercialSpecificId);
		}

		[Fact]
		public void AttachCommercialSpecificId_ShouldNotUpdateCommercialSpecificId_WhenEmpty()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newCommercialSpecificId = Guid.Empty;

			// Act
			commercial.AttachCommercialSpecificId(newCommercialSpecificId);

			// Assert
			commercial.CommercialSpecificId.Should().Be(commercialSpecificId);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldUpdateUsefulSurface_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newUsefulSurface = 300.12;

			// Act
			commercial.AttachUsefulSurface(newUsefulSurface);

			// Assert
			commercial.UsefulSurface.Should().Be(newUsefulSurface);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldNotUpdateUsefulSurface_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			var newUsefulSurface = 0;

			// Act
			commercial.AttachUsefulSurface(newUsefulSurface);

			// Assert
			commercial.UsefulSurface.Should().Be(usefulSurface);
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
			var offerType = false;
			var description = "test description"; 
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachUserId(newUserId);

			// Assert
			commercial.UserId.Should().Be(newUserId);
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
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachUserId(newUserId);

			// Assert
			commercial.UserId.Should().Be(userId);
		}

		[Fact]
		public void AttachTitlePost_ShouldUpdateTitlePost_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "new test title";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachTitlePost(newTitlePost);

			// Assert
			commercial.TitlePost.Should().Be(newTitlePost);
		}

		[Fact]
		public void AttachTitlePost_ShouldNotUpdateTitlePost_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newTitlePost = "";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachTitlePost(newTitlePost);

			// Assert
			commercial.TitlePost.Should().Be(titlePost);
		}

		[Fact]
		public void AttachPrice_ShouldUpdatePrice_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 3000.12;
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachPrice(newPrice);

			// Assert
			commercial.Price.Should().Be(newPrice);
		}

		[Fact]
		public void AttachPrice_ShouldNotUpdatePrice_WhenInvalid()
		{
			// Arrange
			var userId = "test user id";
			var newPrice = 0;
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;

			// Act
			commercial.AttachPrice(newPrice);

			// Assert
			commercial.Price.Should().Be(price);
		}

		[Fact]
		public void AttachAddressId_ShouldUpdateAddressId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.NewGuid();
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var address = Address.Create("https://www.google.com", "test name").Value;
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			commercial.AttachAddress(address);

			// Act
			commercial.AttachAddressId(newAddressId);

			// Assert
			commercial.AddressId.Should().Be(newAddressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotUpdateAddressId_WhenEmpty()
		{
			// Arrange
			var userId = "test user id";
			var newAddressId = Guid.Empty;
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(1);
			var address = Address.Create("https://www.google.com", "test name").Value;
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			commercial.AttachAddress(address);

			// Act
			commercial.AttachAddressId(newAddressId);

			// Assert
			commercial.AddressId.Should().Be(addressId);
		}

		[Fact]
		public void AttachOfferType_ShouldUpdateOfferType_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newOfferType = true;
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false; 
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(12);
			var address = Address.Create("https://www.google.com", "test name").Value;
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			commercial.AttachAddress(address);

			// Act
			commercial.AttachOfferType(newOfferType);

			// Assert
			commercial.OfferType.Should().Be(newOfferType);
		}

		[Fact]
		public void AttachDescription_ShouldUpdateDescription_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var newDescription = "new test description";
			var titlePost = "test title";
			var price = 2000.12;
			var addressId = Guid.NewGuid();
			var offerType = false;
			var description = "test description";
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200.12;
			var disponibility = DateTime.Now.AddDays(14);
			var address = Address.Create("https://www.google.com", "test name").Value;
			var commercial = Commercial.Create(userId, titlePost, price, addressId, offerType, description, commercialSpecificId, usefulSurface, disponibility).Value;
			commercial.AttachAddress(address);

			// Act
			commercial.AttachDescription(newDescription);

			// Asert
			commercial.Description.Should().Be(newDescription);
		}

        [Fact]
        public void Commercial_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
			var category = CommercialCategory.Create("Test Category").Value;
			var specific = CommercialSpecific.Create("Test Specific", category.Id).Value;
            Guid commercialSpecificId =specific.CommercialSpecificId;
            double usefulSurface = 200.0;
            DateTime disponibility = DateTime.Now;
            string userId = "testUser";
            string titlePost = "Test Commercial Post";
            double price = 250000.0;
            Guid addressId = Guid.NewGuid();
            bool offerType = true;
            string description = "This is a test commercial post.";

            // Act
            var commercial = new Commercial(specific, commercialSpecificId, usefulSurface, disponibility, userId, titlePost, price, addressId, offerType, description);

            // Assert
            commercial.Should().NotBeNull();
            commercial.CommercialSpecific.Should().Be(specific);
            commercial.CommercialSpecificId.Should().Be(commercialSpecificId);
            commercial.UsefulSurface.Should().Be(usefulSurface);
            commercial.Disponibility.Should().Be(disponibility);
            commercial.UserId.Should().Be(userId);
            commercial.TitlePost.Should().Be(titlePost);
            commercial.Price.Should().Be(price);
            commercial.AddressId.Should().Be(addressId);
            commercial.OfferType.Should().Be(offerType);
            commercial.Description.Should().Be(description);
        }

    }
}
