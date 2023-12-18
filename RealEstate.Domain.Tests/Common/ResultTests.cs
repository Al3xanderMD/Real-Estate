using FluentAssertions;
using RealEstate.Domain.Common;
using Xunit;

namespace RealEstate.Domain.Common.Tests
{
	public class ResultTests
	{
		[Fact]
		public void Success_Result_Should_Have_IsSuccess_True_And_Value_Set()
		{
			// Arrange
			var value = new object();

			// Act
			var result = Result<object>.Success(value);

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().Be(value);
			result.Error.Should().BeNull();
		}

		[Fact]
		public void Failure_Result_Should_Have_IsSuccess_False_And_Error_Set()
		{
			// Arrange
			var error = "Test Error";

			// Act
			var result = Result<object>.Failure(error);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Value.Should().BeNull();
			result.Error.Should().Be(error);
		}

		[Fact]
		public void Success_Result_Should_Not_Have_Error()
		{
			// Arrange
			var value = new object();

			// Act
			var result = Result<object>.Success(value);

			// Assert
			result.Error.Should().BeNull();
		}

		[Fact]
		public void Failure_Result_Should_Not_Have_Value()
		{
			// Arrange
			var error = "Test Error";

			// Act
			var result = Result<object>.Failure(error);

			// Assert
			result.Value.Should().BeNull();
		}
	}
}
