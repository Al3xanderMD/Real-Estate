namespace RealEstate.Domain.Tests.Entities
{
	public class PartitioningTests
	{
		[Fact]
		public void CreatePartitioning_WithValidArguments_ShouldCreatePartitioning()
		{
			// Arrange
			var partitioningName = "test partitioning name";

			// Act
			var result = Partitioning.Create(partitioningName);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.Type.Should().Be("test partitioning name");
		}

		[Fact]
		public void CreatePartitioning_WithInvalidType_ShouldFail()
		{
			// Arrange
			var partitioningName = "";

			// Act
			var result = Partitioning.Create(partitioningName);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Type' must not be empty");
		}

		[Fact]
		public void AttachType_ShouldUpdateType_WhenValid()
		{
			// Arrange
			var partitioningName = "test partitioning name";
			var partitioning = Partitioning.Create(partitioningName).Value;
			var newType = "new partitioning name";

			// Act
			partitioning.AttachType(newType);

			// Assert
			partitioning.Type.Should().Be(newType);
		}
	}
}
