namespace RealEstate.Domain.Tests.Entities
{
	public class LotClassificationTests
	{
		[Fact]
		public void CreateLotClassification_WithValidArguments_ShouldCreateLotClassification()
		{
			// Arrange
			var type = "test classification";

			// Act
			var result = LotClassification.Create(type);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.Type.Should().Be("test classification");
		}

		[Fact]
		public void CreateLotClassification_WithInvalidType_ShouldFail()
		{
			// Arrange
			var type = "";

			// Act
			var result = LotClassification.Create(type);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Type' must not be empty");
		}

		[Fact]
		public void AttachType_ShouldUpdateType_WhenValid()
		{
			// Arrange
			var type = "test classification";
			var lotClassification = LotClassification.Create(type).Value;
			var newType = "new classification";

			// Act
			lotClassification.AttachType(newType);

			// Assert
			lotClassification.Type.Should().Be(newType);
		}
	}
}
