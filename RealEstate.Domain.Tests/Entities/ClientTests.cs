namespace RealEstate.Domain.Tests.Entities
{
	public class ClientTests
	{
		[Fact]
		public void CreateClient_WithValidArguments_ShouldCreateClient()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "last name";
		
			// Act
			var result = Client.Create(firstName, lastName);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.ClientId.Should().NotBe(Guid.Empty);
			result.Value.FirstName.Should().Be("first name");
			result.Value.LastName.Should().Be("last name");
		}

		[Fact]
		public void CreateClient_WithInvalidFirstName_ShouldFail()
		{
			// Arrange
			var firstName = "";
			var lastName = "last name";
		
			// Act
			var result = Client.Create(firstName, lastName);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("First name is required");
		}

		[Fact]
		public void CreateClient_WithInvalidLastName_ShouldFail()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "";
		
			// Act
			var result = Client.Create(firstName, lastName);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Last name is required");
		}

		[Fact]
		public void AttachPhone_ShouldUpdatePhone_WhenValid()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "last name";
			var client = Client.Create(firstName, lastName).Value;
			var phone = "1234567890";
		
			// Act
			client.AttachPhone(phone);
		
			// Assert
			client.Phone.Should().Be("1234567890");
		}

		[Fact]
		public void AttachPhone_ShouldNotUpdatePhone_WhenInvalid()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "last name";
			var client = Client.Create(firstName, lastName).Value;
			var phone = "123456789";
		
			// Act
			client.AttachPhone(phone);
		
			// Assert
			client.Phone.Should().BeNull();
		}

		[Fact]
		public void AttachRegion_ShouldUpdateRegion_WhenValid()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "last name";
			var client = Client.Create(firstName, lastName).Value;
			var region = "test region";
		
			// Act
			client.AttachRegion(region);
		
			// Assert
			client.Region.Should().Be("test region");
		}

		[Fact]
		public void AttachRegion_ShouldNotUpdateRegion_WhenInvalid()
		{
			// Arrange
			var firstName = "first name";
			var lastName = "last name";
			var client = Client.Create(firstName, lastName).Value;
			var region = "";
		
			// Act
			client.AttachRegion(region);
		
			// Assert
			client.Region.Should().BeNull();
		}

	}
}
