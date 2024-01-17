namespace RealEstate.Domain.Tests.Entities
{
	public class BasePostTests
	{
		[Fact]
		public void CreatePost_WithValidArguments_ShouldCreatePost()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();

			// Act
			var result = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description");

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.BasePostId.Should().NotBe(Guid.Empty);
			result.Value.UserId.Should().Be(userId);
			result.Value.TitlePost.Should().Be("test Title");
			result.Value.Price.Should().Be(2000.12);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.OfferType.Should().BeFalse();
		}

		[Fact]
		public void CreatePost_WithInvalidTitle_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();

			// Act
			var result = BasePost.Create(userId, "", 2000.12, addressId, false, "test description");

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'TitlePost' must not be empty");
		}

		[Fact]
		public void CreatePost_WithInvalidPrice_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();

			// Act
			var result = BasePost.Create(userId, "test Title", 0, addressId, false, "test description");

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Price' must be greater than 0");
		}

		[Fact]
		public void CreatePost_WithInvalidAddressId_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.Empty;

			// Act
			var result = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description");

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'AddressId' must not be empty");
		}

		[Fact]
		public void CreatePost_WithInvalidDescription_ShouldFail()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var description = "";

			// Act
			var result = BasePost.Create(userId, "test Title", 2000.12, addressId, false, description);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Description' must not be empty");
		}

		[Fact]
		public void AttachDescription_ShouldUpdateDescription_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachDescription("test description");

			// Assert
			post.Description.Should().Be("test description");
		}

		[Fact]
		public void AttachImages_ShouldUpdateImages_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachImages(new List<string> { "image1", "image2" });

			// Assert
			post.Images.Should().HaveCount(2);
			post.Images.Should().Contain("image1");
			post.Images.Should().Contain("image2");
		}

		[Fact]
		public void AttachAddressId_ShouldUpdateAddressId_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachAddressId(Guid.NewGuid());

			// Assert
			post.AddressId.Should().NotBe(addressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotUpdateAddressId_WhenEmpty()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachAddressId(Guid.Empty);

			// Assert
			post.AddressId.Should().Be(addressId);
		}

		[Fact]
		public void AttachAddress_ShouldUpdateAddress_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;
			var newAddress = Address.Create("https://www.google.com", "test name").Value;

			// Act
			post.AttachAddress(newAddress);

			// Assert
			post.Address.Should().Be(newAddress);
		}

		[Fact]
		public void AttachTitle_ShouldUpdateTitle_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachTitlePost("new title");

			// Assert
			post.TitlePost.Should().Be("new title");
		}

		[Fact]
		public void AttachPrice_ShouldUpdatePrice_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, false, "test description").Value;

			// Act
			post.AttachPrice(3000.12);

			// Assert
			post.Price.Should().Be(3000.12);
		}

		[Fact]
		public void AttachOfferType_ShouldUpdateOfferType_WhenValid()
		{
			// Arrange
			var userId = "test user id";
			var addressId = Guid.NewGuid();
			var post = BasePost.Create(userId, "test Title", 2000.12, addressId, true, "test description").Value;

			// Act
			post.AttachOfferType(false);

			// Assert
			post.OfferType.Should().BeFalse();
		}

        [Fact]
        public void BasePost_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            string userId = "testUser";
            string titlePost = "Test Post";
            double price = 150000.0;
            Guid addressId = Guid.NewGuid();
            Address address = new Address("Test Url", "Test Name"); // You need to provide an instance of the Address class
            bool offerType = true;
            string description = "This is a test post.";

            // Act
            var basePost = new BasePost(userId, titlePost, price, addressId, address, offerType, description);

            // Assert
            basePost.Should().NotBeNull();
            basePost.UserId.Should().Be(userId);
            basePost.TitlePost.Should().Be(titlePost);
            basePost.Price.Should().Be(price);
            basePost.AddressId.Should().Be(addressId);
            basePost.Address.Should().Be(address);
            basePost.OfferType.Should().Be(offerType);
            basePost.Description.Should().Be(description);
        }

    }

}
