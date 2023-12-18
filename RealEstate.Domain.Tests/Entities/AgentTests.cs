namespace RealEstate.Domain.Entities.Tests
{
	public class AgentTests
	{
		[Fact]
		public void Create_Agent_With_Valid_Parameters_Should_Return_Success_Result()
		{
			// Arrange
			var addressId = Guid.NewGuid();
			var agentName = "John Doe";
			var phone = "1234567890";

			// Act
			var result = Agent.Create(addressId, agentName, phone);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.AgentId.Should().NotBe(Guid.Empty);
			result.Value.AddressId.Should().Be(addressId);
			result.Value.AgentName.Should().Be(agentName);
			result.Value.Phone.Should().Be(phone);
		}

		[Fact]
		public void Create_Agent_With_Empty_AgentName_Should_Return_Failure_Result()
		{
			// Arrange
			var addressId = Guid.NewGuid();
			var agentName = "";
			var phone = "1234567890";

			// Act
			var result = Agent.Create(addressId, agentName, phone);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Agent name is required");
			result.Value.Should().BeNull();
		}

		[Fact]
		public void Create_Agent_With_Empty_Phone_Should_Return_Failure_Result()
		{
			// Arrange
			var addressId = Guid.NewGuid();
			var agentName = "John Doe";
			var phone = "";

			// Act
			var result = Agent.Create(addressId, agentName, phone);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Phone is required");
			result.Value.Should().BeNull();
		}

		[Fact]
		public void Attach_Logo_Should_Update_Logolink_When_Valid()
		{
			// Arrange
			var address = Address.Create("http://example.com", "Address Name").Value;
			var agent = Agent.Create(address.Id, "John Doe", "1234567890").Value;

			// Act
			agent.AttachLogo("logo.png");

			// Assert
			agent.Logolink.Should().Be("logo.png");
		}

		[Fact]
		public void Attach_Logo_Should_Not_Update_Logolink_When_Invalid()
		{
			// Arrange
			var address = Address.Create("http://example.com", "Address Name").Value;
			var agent = Agent.Create(address.Id, "John Doe", "1234567890").Value;

			// Act
			agent.AttachLogo("");

			// Assert
			agent.Logolink.Should().BeNull();
		}

		[Fact]
		public void Attach_Url_Should_Update_Url_When_Valid()
		{
			// Arrange
			var address = Address.Create("http://example.com", "Address Name").Value; 
			var agent = Agent.Create(address.Id, "John Doe", "1234567890").Value;

			// Act
			agent.AttachUrl("http://example.com");

			// Assert
			agent.Url.Should().Be("http://example.com");
		}

		[Fact]
		public void Attach_Url_Should_Not_Update_Url_When_Invalid()
		{
			// Arrange
			var address = Address.Create("http://example.com", "Address Name").Value;
			var agent = Agent.Create(address.Id, "John Doe", "1234567890").Value;

			// Act
			agent.AttachUrl("");

			// Assert
			agent.Url.Should().BeNull();
		}
	}
}
