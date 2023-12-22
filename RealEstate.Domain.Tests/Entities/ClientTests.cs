namespace RealEstate.Domain.Tests.Entities
{
	public class ClientTests
	{
		[Fact]
		public void CreateClient_WithValidArguments_ShouldCreateClient()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.UserId.Should().Be(userId);
			result.Value.Username.Should().Be(username);
			result.Value.Email.Should().Be(email);
			result.Value.Name.Should().Be(name);
			result.Value.PhoneNumber.Should().Be(phoneNumber);
		}

		[Fact]
		public void CreateClient_WithInvalidUsername_ShouldFail()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Username is required");
		}

		[Fact]
		public void CreateClient_WithInvalidEmail_ShouldFail()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "";
			var name = "test name";
			var phoneNumber = "test phone number";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Email is required");
		}

		[Fact]
		public void CreateClient_WithInvalidName_ShouldFail()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "";
			var phoneNumber = "test phone number";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Name is required");
		}

		[Fact]
		public void CreateClient_WithInvalidPhoneNumber_ShouldFail()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Phone number is required");
		}

		[Fact]
		public void CreateClient_WithInvalidUserId_ShouldFail()
		{
			// Arrange
			var userId = Guid.Empty;
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";

			// Act
			var result = Client.Create(userId, username, email, name, phoneNumber);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("UserId is required");
		}

		[Fact]
		public void AttachName_ShouldUpdateName_WhenValid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newName = "new name";

			// Act
			client.AttachName(newName);

			// Assert
			client.Name.Should().Be(newName);
		}

		[Fact]
		public void AttachName_ShouldNotUpdateName_WhenInvalid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newName = "";

			// Act
			client.AttachName(newName);

			// Assert
			client.Name.Should().Be(name);
		}

		[Fact]
		public void AttachPhoneNumber_ShouldUpdatePhoneNumber_WhenValid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newPhoneNumber = "new phone number";

			// Act
			client.AttachPhoneNumber(newPhoneNumber);

			// Assert
			client.PhoneNumber.Should().Be(newPhoneNumber);
		}

		[Fact]
		public void AttachPhoneNumber_ShouldNotUpdatePhoneNumber_WhenInvalid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newPhoneNumber = "";

			// Act
			client.AttachPhoneNumber(newPhoneNumber);

			// Assert
			client.PhoneNumber.Should().Be(phoneNumber);
		}

		[Fact]
		public void AttachImageUrl_ShouldUpdateImageUrl_WhenValid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newImageUrl = "new image url";

			// Act
			client.AttachImageUrl(newImageUrl);

			// Assert
			client.ImageUrl.Should().Be(newImageUrl);
		}

		[Fact]
		public void AttachImageUrl_ShouldNotUpdateImageUrl_WhenInvalid()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var username = "test username";
			var email = "test email";
			var name = "test name";
			var phoneNumber = "test phone number";
			var client = Client.Create(userId, username, email, name, phoneNumber).Value;
			var newImageUrl = "";

			// Act
			client.AttachImageUrl(newImageUrl);

			// Assert
			client.ImageUrl.Should().Be(null);
		}
	}
}
