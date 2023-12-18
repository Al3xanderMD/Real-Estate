namespace RealEstate.Domain.Tests.Entities
{
	public class CommercialTests
	{
		[Fact]
		public void CreateCommercial_WithValidArguments_ShouldCreateCommercial()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;

			// Act
			var result = Commercial.Create(basePostId, commercialSpecificId, usefulSurface);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.Id.Should().NotBe(Guid.Empty);
			result.Value.BasePostId.Should().Be(basePostId);
			result.Value.CommercialSpecificId.Should().Be(commercialSpecificId);
			result.Value.UsefulSurface.Should().Be(200);
		}

		[Fact]
		public void CreateCommercial_WithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 0;

			// Act
			var result = Commercial.Create(basePostId, commercialSpecificId, usefulSurface);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("Useful surface must be greater than 0");
		}

		[Fact]
		public void AttachDisponibility_ShouldUpdateDisponibility_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var disponibility = DateTime.Now;

			// Act
			commercial.AttachDisponibility(disponibility);

			// Assert
			commercial.Disponibility.Should().Be(disponibility);
		}

		[Fact]
		public void AttachDisponibility_ShouldNotUpdateDisponibility_WhenNull()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var disponibility = DateTime.Now;
			commercial.AttachDisponibility(disponibility);

			// Act
			commercial.AttachDisponibility(null);

			// Assert
			commercial.Disponibility.Should().Be(disponibility);
		}

		[Fact]
		public void AttachBasePostId_ShouldUpdateBasePostId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newBasePostId = Guid.NewGuid();

			// Act
			commercial.AttachBasePostId(newBasePostId);

			// Assert
			commercial.BasePostId.Should().Be(newBasePostId);
		}

		[Fact]
		public void AttachBasePostId_ShouldNotUpdateBasePostId_WhenEmpty()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newBasePostId = Guid.Empty;

			// Act
			commercial.AttachBasePostId(newBasePostId);

			// Assert
			commercial.BasePostId.Should().Be(basePostId);
		}

		[Fact]
		public void AttachCommercialSpecificId_ShouldUpdateCommercialSpecificId_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newCommercialSpecificId = Guid.NewGuid();

			// Act
			commercial.AttachCommercialSpecificId(newCommercialSpecificId);

			// Assert
			commercial.CommercialSpecificId.Should().Be(newCommercialSpecificId);
		}

		[Fact]
		public void AttachCommercialSpecificId_ShouldNotUpdateCommercialSpecificId_WhenEmpty()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newCommercialSpecificId = Guid.Empty;

			// Act
			commercial.AttachCommercialSpecificId(newCommercialSpecificId);

			// Assert
			commercial.CommercialSpecificId.Should().Be(commercialSpecificId);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldUpdateUsefulSurface_WhenValid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newUsefulSurface = 300;

			// Act
			commercial.AttachUsefulSurface(newUsefulSurface);

			// Assert
			commercial.UsefulSurface.Should().Be(newUsefulSurface);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldNotUpdateUsefulSurface_WhenInvalid()
		{
			// Arrange
			var basePostId = Guid.NewGuid();
			var commercialSpecificId = Guid.NewGuid();
			var usefulSurface = 200;
			var commercial = Commercial.Create(basePostId, commercialSpecificId, usefulSurface).Value;
			var newUsefulSurface = 0;

			// Act
			commercial.AttachUsefulSurface(newUsefulSurface);

			// Assert
			commercial.UsefulSurface.Should().Be(usefulSurface);
		}
	}
}