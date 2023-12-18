namespace RealEstate.Domain.Tests.Entities
{
	public class CommercialCategoryTests
	{
		[Fact]
		public void CreateCommercialCategory_WithValidArguments_ShouldCreateCommercialCategory()
		{
			// Arrange
			var categoryName = "test category name";
		
			// Act
			var result = CommercialCategory.Create(categoryName);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.CategoryName.Should().Be("test category name");
		}

		[Fact]
		public void CreateCommercialCategory_WithInvalidCategoryName_ShouldFail()
		{
			// Arrange
			var categoryName = "";
		
			// Act
			var result = CommercialCategory.Create(categoryName);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Category name is required");
		}

		[Fact]
		public void AttachCategoryName_ShouldUpdateCategoryName_WhenValid()
		{
			// Arrange
			var categoryName = "test category name";
			var commercialCategory = CommercialCategory.Create(categoryName).Value;
			var newCategoryName = "new category name";
		
			// Act
			commercialCategory.AttachCategoryName(newCategoryName);
		
			// Assert
			commercialCategory.CategoryName.Should().Be(newCategoryName);
		}
	}
}
