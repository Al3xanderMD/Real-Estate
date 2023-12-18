namespace RealEstate.Domain.Tests.Entities
{
	public class CommercialSpecificTests
	{
		[Fact]
		public void CreateCommercialSpecific_WithValidArguments_ShouldCreateCommercialSpecific()
		{
			// Arrange
			var specificName = "test specific name";
			var commercialCategoryId = Guid.NewGuid();
		
			// Act
			var result = CommercialSpecific.Create(specificName, commercialCategoryId);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.CommercialSpecificId.Should().NotBe(Guid.Empty);
			result.Value.SpecificName.Should().Be("test specific name");
			result.Value.CommercialCategoryId.Should().Be(commercialCategoryId);
		}

		[Fact]
		public void CreateCommercialSpecific_WithInvalidSpecificName_ShouldFail()
		{
			// Arrange
			var specificName = "";
			var commercialCategoryId = Guid.NewGuid();
		
			// Act
			var result = CommercialSpecific.Create(specificName, commercialCategoryId);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Specific name is required");
		}

		[Fact]
		public void AttachSpecificName_ShouldUpdateSpecificName_WhenValid()
		{
			// Arrange
			var specificName = "test specific name";
			var commercialCategoryId = Guid.NewGuid();
			var commercialSpecific = CommercialSpecific.Create(specificName, commercialCategoryId).Value;
			var newSpecificName = "new specific name";
		
			// Act
			commercialSpecific.AttachSpecificName(newSpecificName);
		
			// Assert
			commercialSpecific.SpecificName.Should().Be(newSpecificName);
		}

		[Fact]
		public void AttachCommercialCategoryId_ShouldUpdateCommercialCategoryId_WhenValid()
		{
			// Arrange
			var specificName = "test specific name";
			var commercialCategoryId = Guid.NewGuid();
			var commercialSpecific = CommercialSpecific.Create(specificName, commercialCategoryId).Value;
			var newCommercialCategoryId = Guid.NewGuid();
		
			// Act
			commercialSpecific.AttachCommercialCategoryId(newCommercialCategoryId);
		
			// Assert
			commercialSpecific.CommercialCategoryId.Should().Be(newCommercialCategoryId);
		}

		[Fact]
		public void AttachCommercialCategoryId_ShouldNotUpdateCommercialCategoryId_WhenNull()
		{
			// Arrange
			var specificName = "test specific name";
			var commercialCategoryId = Guid.NewGuid();
			var commercialSpecific = CommercialSpecific.Create(specificName, commercialCategoryId).Value;
			var newCommercialCategoryId = Guid.Empty;
		
			// Act
			commercialSpecific.AttachCommercialCategoryId(newCommercialCategoryId);
		
			// Assert
			commercialSpecific.CommercialCategoryId.Should().Be(commercialCategoryId);
		}


	}
}
