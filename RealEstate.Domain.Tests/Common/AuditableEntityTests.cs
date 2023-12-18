namespace RealEstate.Domain.Tests.Common
{
	public class AuditableEntityTests
	{
		[Fact]
		public void CreatedBy_Should_Be_Null_By_Default()
		{
			// Arrange
			var auditableEntity = new AuditableEntity();

			// Act
			var createdBy = auditableEntity.CreatedBy;

			// Assert
			createdBy.Should().BeNull();
		}

		[Fact]
		public void CreatedDate_Should_Have_Default_DateTime()
		{
			// Arrange
			var auditableEntity = new AuditableEntity();

			// Act
			var createdDate = auditableEntity.CreatedDate;

			// Assert
			createdDate.Should().Be(default(DateTime));
		}

		[Fact]
		public void LastModifiedBy_Should_Be_Null_By_Default()
		{
			// Arrange
			var auditableEntity = new AuditableEntity();

			// Act
			var lastModifiedBy = auditableEntity.LastModifiedBy;

			// Assert
			lastModifiedBy.Should().BeNull();
		}

		[Fact]
		public void LastModifiedDate_Should_Have_Default_DateTime()
		{
			// Arrange
			var auditableEntity = new AuditableEntity();

			// Act
			var lastModifiedDate = auditableEntity.LastModifiedDate;

			// Assert
			lastModifiedDate.Should().Be(default(DateTime));
		}

		[Fact]
		public void Setting_Properties_Should_Work_Correctly()
		{
			// Arrange
			var auditableEntity = new AuditableEntity();

			// Act
			auditableEntity.CreatedBy = "user1";
			auditableEntity.CreatedDate = DateTime.Now;
			auditableEntity.LastModifiedBy = "user2";
			auditableEntity.LastModifiedDate = DateTime.Now;

			// Assert
			auditableEntity.CreatedBy.Should().Be("user1");
			auditableEntity.CreatedDate.Should().NotBe(default(DateTime));
			auditableEntity.LastModifiedBy.Should().Be("user2");
			auditableEntity.LastModifiedDate.Should().NotBe(default(DateTime));
		}

	}
}
