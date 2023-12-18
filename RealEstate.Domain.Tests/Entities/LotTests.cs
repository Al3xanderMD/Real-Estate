namespace RealEstate.Domain.Tests.Entities
{
	public class LotTests
	{
		[Fact]
		public void CreateLot_WithValidArguments_ShouldCreateLot()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
		
			// Act
			var result = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId);
		
			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.BasePostId.Should().Be(basePostId);
			result.Value.LotArea.Should().Be(lotArea);
			result.Value.StreetFrontage.Should().Be(streetFrontage);
			result.Value.LotClassificationId.Should().Be(lotClassificationId);
		}

		[Fact]
		public void CreateLot_WithInvalidLotArea_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 0;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
		
			// Act
			var result = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Lot area must be larger than 0.");
		}

		[Fact]
		public void CreateLot_WithInvalidStreetFrontage_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 0;
			var lotClassificationId = Guid.NewGuid();
		
			// Act
			var result = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId);
		
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Street frontage must be larger than 0.");
		}

		[Fact]
		public void AttachBasePostId_ShouldUpdateBasePostId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newBasePostId = Guid.NewGuid();
		
			// Act
			lot.AttachBasePostId(newBasePostId);
		
			// Assert
			lot.BasePostId.Should().Be(newBasePostId);
		}

		[Fact]
		public void AttachBasePostId_ShouldNotUpdateBasePostId_WhenNull()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newBasePostId = Guid.Empty;

			// Act
			lot.AttachBasePostId(newBasePostId);
		
			// Assert
			lot.BasePostId.Should().Be(basePostId);
		}

		[Fact]
		public void AttachBasePost_ShouldUpdateBasePost_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			// Create(Guid userId, string titlePost, double price, Guid addressId, bool offerType)
			var userId = Guid.NewGuid();
			var addressId = Guid.NewGuid();
			var newBasePost = BasePost.Create(userId, "test Title", 2000.12, addressId, false).Value;
		
			// Act
			lot.AttachBasePost(newBasePost);
		
			// Assert
			lot.BasePost.Should().Be(newBasePost);
		}

		[Fact]
		public void AttachLotClassificationId_ShouldUpdateLotClassificationId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotClassificationId = Guid.NewGuid();
		
			// Act
			lot.AttachLotClassificationId(newLotClassificationId);
		
			// Assert
			lot.LotClassificationId.Should().Be(newLotClassificationId);
		}

		[Fact]
		public void AttachLotClassificationId_ShouldNotUpdateLotClassificationId_WhenEmpty()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotClassificationId = Guid.Empty;
		
			// Act
			lot.AttachLotClassificationId(newLotClassificationId);
		
			// Assert
			lot.LotClassificationId.Should().Be(lotClassificationId);
		}

		[Fact]
		public void AttachLotClassification_ShouldUpdateLotClassification_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotClassification = LotClassification.Create("test type").Value;
		
			// Act
			lot.AttachLotClassification(newLotClassification);
		
			// Assert
			lot.LotClassification.Should().Be(newLotClassification);
		}

		[Fact]
		public void AttachLotArea_ShouldUpdateLotArea_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newLotArea = 200;
		
			// Act
			lot.AttachLotArea(newLotArea);
		
			// Assert
			lot.LotArea.Should().Be(newLotArea);
		}

		[Fact]
		public void AttachStreetFrontage_ShouldUpdateStreetFrontage_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var lotArea = 100;
			var streetFrontage = 100;
			var lotClassificationId = Guid.NewGuid();
			var lot = Lot.Create(basePostId, lotArea, streetFrontage, lotClassificationId).Value;
			var newStreetFrontage = 200;
		
			// Act
			lot.AttachStreetFrontage(newStreetFrontage);
		
			// Assert
			lot.StreetFrontage.Should().Be(newStreetFrontage);
		}
	}
}
