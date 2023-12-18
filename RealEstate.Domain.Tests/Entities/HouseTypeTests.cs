namespace RealEstate.Domain.Tests.Entities
{
	public class HouseTypeTests
	{
		[Fact]
		public void CreateHouseType_WithValidArguments_ShouldCreateHouseType()
		{
			// Arrange
			var type = "test type";
		
			// Act
			var result = HouseType.Create(type);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.Type.Should().Be("test type");
		}

		[Fact]
		public void CreateHouseType_WithInvalidType_ShouldFail()
		{
			// Arrange
			var type = "";
		
			// Act
			var result = HouseType.Create(type);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Type' must not be empty");
		}

		[Fact]
		public void AttachType_ShouldUpdateType_WhenValid()
		{
			// Arrange
			var type = "test type";
			var houseType = HouseType.Create(type).Value;
			var newType = "new type";
		
			// Act
			houseType.AttachType(newType);
		
			// Assert
			houseType.Type.Should().Be(newType);
		}
	}
}
