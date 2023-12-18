namespace RealEstate.Domain.Tests.Entities
{
	public class AddressTests
	{
		[Fact]
		public void When_Create_Address_With_Empty_Url_Should_Return_Failure()
		{
			// Arrange
			var url = string.Empty;
			var addressName = "Test Address";

			// Act
			var result = Address.Create(url, addressName);

			// Assert
			result.IsSuccess.Should().BeFalse();
			Assert.Equal("Url is required", result.Error);
		}

		[Fact]
		public void When_Create_Address_With_Empty_AddressName_Should_Return_Failure()
		{
			// Arrange
			var url = "https://www.google.com";
			var addressName = string.Empty;

			// Act
			var result = Address.Create(url, addressName);

			// Assert
			result.IsSuccess.Should().BeFalse();
			Assert.Equal("Address name is required", result.Error);
		}

		[Fact]
		public void When_Create_Address_With_Valid_Url_And_AddressName_Should_Return_Success()
		{
			// Arrange
			var url = "https://www.google.com";
			var addressName = "Test Address";

			// Act
			var result = Address.Create(url, addressName);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Url.Should().Be(url);
			result.Value.AddressName.Should().Be(addressName);
		}

		[Fact]
		public void When_Attach_AddressName_With_Valid_AddressName_Should_Return_Success()
		{
			// Arrange
			var url = "https://www.google.com";
			var addressName = "Test Address";
			var address = Address.Create(url, addressName).Value;
			var newAddressName = "New Address Name";

			// Act
			address.AttachAddressName(newAddressName);

			// Assert
			address.AddressName.Should().Be(newAddressName);
		}

		[Fact]
		public void When_Attach_AddressName_With_Empty_AddressName_Should_Return_Success()
		{
			// Arrange
			var url = "https://www.google.com";
			var addressName = "Test Address";
			var address = Address.Create(url, addressName).Value;
			var newAddressName = string.Empty;

			// Act
			address.AttachAddressName(newAddressName);

			// Assert
			address.AddressName.Should().Be(addressName);
		}

	}
}
