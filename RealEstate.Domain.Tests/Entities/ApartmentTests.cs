using System.Diagnostics.Metrics;
using System.Net.WebSockets;

namespace RealEstate.Domain.Tests.Entities
{
	public class ApartmentTests
	{
		[Fact]
		public void Create_ApartmentWithValidData_ShouldSucceed()
		{
			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(), 
							true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeTrue();
			result.Value.Should().NotBeNull();
			result.Value.UserId.Should().Be("userId");
			result.Value.TitlePost.Should().Be("titlePost");
			result.Value.Price.Should().Be(100);
			result.Value.AddressId.Should().NotBe(Guid.Empty);
			result.Value.OfferType.Should().BeTrue();
			result.Value.Description.Should().Be("description");
			result.Value.RoomCount.Should().Be(2);
			result.Value.Comfort.Should().Be(3);
			result.Value.Floor.Should().Be(1);
			result.Value.UsefulSurface.Should().Be(75.5);
			result.Value.BuildYear.Should().Be(2000);
			result.Value.PartitioningId.Should().NotBe(Guid.Empty);
		}

		[Fact]
		public void Create_ApartmentWithInvalidTitlePost_ShouldFail()
		{
			// Arrange
			var titlePost = "";

			// Act
			var result = Apartment.Create("userId", titlePost, 100, Guid.NewGuid(),
											true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'TitlePost' must not be empty");
		}

		[Fact]
		public void Create_ApartmentWithInvalidPrice_ShouldFail()
		{
			// Arrange
			var price = 0;

			// Act
			var result = Apartment.Create("userId", "titlePost", price, Guid.NewGuid(),
															true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Price' must be greater than 0");
		}

		[Fact]
		public void Create_ApartmentWithInvalidAddressId_ShouldFail()
		{
			// Arrange
			var addressId = Guid.Empty;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, addressId,
																			true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'AddressId' must not be empty");
		}

		[Fact]
		public void Create_ApartmentWithInvalidRoomCount_ShouldFail()
		{
			// Arrange
			var roomCount = 0;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
							true, "description", roomCount, 3, 1, 75.5, 2000, Guid.NewGuid());
			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'RoomCount' must be greater than 0");
		}

		[Fact]
		public void Create_ApartmentWithInvalidComfort_ShouldFail()
		{
			// Arrange
			var comfort1 = 0;
			var comfort2 = 5;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
							true, "description", 2, comfort1, 1, 75.5, 2000, Guid.NewGuid());
			var result2 = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
							true, "description", 2, comfort2, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Comfort' must be greater than 0 and less than 5");
			result2.IsSuccess.Should().BeFalse();
			result2.Error.Should().Be("'Comfort' must be greater than 0 and less than 5");
		}

		[Fact]
		public void Create_ApartmentWithInvalidFloor_ShouldFail()
		{
			// Arrange
			var floor = 0;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
															true, "description", 2, 3, floor, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Floor' must be greater than 0");
		}

		[Fact]
		public void Create_ApartmentWithInvalidUsefulSurface_ShouldFail()
		{
			// Arrange
			var usefulSurface = 0;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
											true, "description", 2, 3, 1, usefulSurface, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'UsefulSurface' must be greater than 0");
		}

		[Fact]
		public void Create_ApartmentWithInvalidBuildYear_ShouldFail()
		{
			// Arrange
			var buildYear1 = 1800;
			var buildYear2 = 2491;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
											true, "description", 2, 3, 1, 75.5, buildYear1, Guid.NewGuid());
			var result2 = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
															true, "description", 2, 3, 1, 75.5, buildYear2, Guid.NewGuid());
			// Assert
			result.IsSuccess.Should().BeFalse();
			var str = "'BuildYear' must be after 1900 and before " + DateTime.Now.Year + 1;
			result.Error.Should().Be(str);
			result2.IsSuccess.Should().BeFalse();
			result2.Error.Should().Be(str);
		}

		[Fact]
		public void Create_ApartmentWithInvalidPartitioningId_ShouldFail()
		{
			// Arrange
			var partitioningId = Guid.Empty;

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
															true, "description", 2, 3, 1, 75.5, 2000, partitioningId);

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'PartitioningId' must not be empty");
		}

		[Fact]
		public void Create_ApartmentWithInvalidDescription_ShouldFail()
		{
			// Arrange
			var description = "";

			// Act
			var result = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																			true, description, 2, 3, 1, 75.5, 2000, Guid.NewGuid());

			// Assert
			result.IsSuccess.Should().BeFalse();
			result.Error.Should().Be("'Description' must not be empty");
		}

		[Fact]
		public void AttachPartitioning_ShouldSetPartitioning()
		{
			// Arrange
			var partitioning = Partitioning.Create("test partitioning name").Value;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
										true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachPartitioning(partitioning);

			// Assert
			apartment.Partitioning.Should().Be(partitioning);
		}

		[Fact]
		public void AttachRoomCount_ShouldSetRoomCount()
		{
			// Arrange
			var roomCount = 3;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
									true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachRoomCount(roomCount);

			// Assert
			apartment.RoomCount.Should().Be(roomCount);
		}

		[Fact]
		public void AttachRoomCount_ShouldNotSetRoomCount_WhenInvalid()
		{
			// Arrange
			var roomCount = 0;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
													true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachRoomCount(roomCount);

			// Assert
			apartment.RoomCount.Should().NotBe(roomCount);
		}

		[Fact]
		public void AttachComfort_ShouldSetComfort()
		{
			// Arrange
			var comfort = 3;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
													true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachComfort(comfort);

			// Assert
			apartment.Comfort.Should().Be(comfort);
		}

		[Fact]
		public void AttachComfort_ShouldNotSetComfort_WhenInvalid()
		{
			// Arrange
			var comfort1 = 0;
			var comfort2 = 5;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																	true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;
			var apartment2 = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																	true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;
			// Act
			apartment.AttachComfort(comfort1);
			apartment2.AttachComfort(comfort2);

			// Assert
			apartment.Comfort.Should().NotBe(comfort1);
			apartment2.Comfort.Should().NotBe(comfort2);
		}

		[Fact]
		public void AttachFloor_ShouldSetFloor()
		{
			// Arrange
			var floor = 3;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																	true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachFloor(floor);

			// Assert
			apartment.Floor.Should().Be(floor);
		}

		[Fact]
		public void AttachFloor_ShouldNotSetFloor_WhenInvalid()
		{
			// Arrange
			var floor = 0;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																					true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachFloor(floor);

			// Assert
			apartment.Floor.Should().NotBe(floor);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldSetUsefulSurface()
		{
			// Arrange
			var usefulSurface = 75.5;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																									true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachUsefulSurface(usefulSurface);

			// Assert
			apartment.UsefulSurface.Should().Be(usefulSurface);
		}

		[Fact]
		public void AttachUsefulSurface_ShouldNotSetUsefulSurface_WhenInvalid()
		{
			// Arrange
			var usefulSurface = 0;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																													true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachUsefulSurface(usefulSurface);

			// Assert
			apartment.UsefulSurface.Should().NotBe(usefulSurface);
		}

		[Fact]
		public void AttachBuildYear_ShouldSetBuildYear()
		{
			// Arrange
			var buildYear = 2000;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																																	true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachBuildYear(buildYear);

			// Assert
			apartment.BuildYear.Should().Be(buildYear);
		}

		[Fact]
		public void AttachBuildYear_ShouldNotSetBuildYear_WhenInvalid()
		{
			// Arrange
			var buildYear1 = 1800;
			var buildYear2 = 2491;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																																					true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;
			var apartment2 = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																																					true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachBuildYear(buildYear1);
			apartment2.AttachBuildYear(buildYear2);

			// Assert
			apartment.BuildYear.Should().NotBe(buildYear1);
			apartment2.BuildYear.Should().NotBe(buildYear2);
		}

		[Fact]
		public void AttachPartitioningId_ShouldSetPartitioningId()
		{
			// Arrange
			var partitioningId = Guid.NewGuid();
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																																					true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachPartitioningId(partitioningId);

			// Assert
			apartment.PartitioningId.Should().Be(partitioningId);
		}

		[Fact]
		public void AttachPartitioningId_ShouldNotSetPartitioningId_WhenInvalid()
		{
			// Arrange
			var partitioningId = Guid.Empty;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachPartitioningId(partitioningId);

			// Assert
			apartment.PartitioningId.Should().NotBe(partitioningId);
		}

		[Fact]
		public void AttachUserId_ShouldSetUserId()
		{
			// Arrange
			var userId = "userId";
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachUserId(userId);

			// Assert
			apartment.UserId.Should().Be(userId);
		}

		[Fact]
		public void AttachUserId_ShouldNotSetUserId_WhenInvalid()
		{
			// Arrange
			var userId = "";
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),
																																																									true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachUserId(userId);

			// Assert
			apartment.UserId.Should().NotBe(userId);
		}

		[Fact]
		public void AttachTitlePost_ShouldSetTitlePost()
		{
			// Arrange
			var titlePost = "titlePost";
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachTitlePost(titlePost);

			// Assert
			apartment.TitlePost.Should().Be(titlePost);
		}

		[Fact]
		public void AttachTitlePost_ShouldNotSetTitlePost_WhenInvalid()
		{
			// Arrange
			var titlePost = "";
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachTitlePost(titlePost);

			// Assert
			apartment.TitlePost.Should().NotBe(titlePost);
		}

		[Fact]
		public void AttachPrice_ShouldSetPrice()
		{
			// Arrange
			var price = 100;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachPrice(price);

			// Assert
			apartment.Price.Should().Be(price);
		}

		[Fact]
		public void AttachPrice_ShouldNotSetPrice_WhenInvalid()
		{
			// Arrange
			var price = 0;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachPrice(price);

			// Assert
			apartment.Price.Should().NotBe(price);
		}

		[Fact]
		public void AttachAddressId_ShouldSetAddressId()
		{
			// Arrange
			var addressId = Guid.NewGuid();
			var apartment = Apartment.Create("userId", "titlePost", 100, addressId,true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachAddressId(addressId);

			// Assert
			apartment.AddressId.Should().Be(addressId);
		}

		[Fact]
		public void AttachAddressId_ShouldNotSetAddressId_WhenInvalid()
		{
			// Arrange
			var addressId = Guid.Empty;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),true, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachAddressId(addressId);

			// Assert
			apartment.AddressId.Should().NotBe(addressId);
		}

		[Fact]
		public void AttachOfferType_ShouldSetOfferType()
		{
			// Arrange
			var offerType = true;
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),false, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachOfferType(offerType);

			// Assert
			apartment.OfferType.Should().Be(offerType);
		}

		[Fact]
		public void AttachDescription_ShouldSetDescription()
		{
			// Arrange
			var description = "description";
			var apartment = Apartment.Create("userId", "titlePost", 100, Guid.NewGuid(),false, "description", 2, 3, 1, 75.5, 2000, Guid.NewGuid()).Value;

			// Act
			apartment.AttachDescription(description);

			// Assert
			apartment.Description.Should().Be(description);
		}

        [Fact]
        public void Apartment_Constructor_Should_Set_Properties_Correctly()
        {
            // Arrange
            var partitioning = new Partitioning("Test Type"); // You need to provide an instance of Partitioning
            int roomCount = 2;
            int comfort = 3;
            int floor = 4;
            double usefulSurface = 100.0;
            int buildYear = 2022;
            Guid partitioningId = Guid.NewGuid();
            string userId = "testUser";
            string titlePost = "Test Apartment";
            double price = 150000.0;
            Guid addressId = Guid.NewGuid();
            bool offerType = true;
            string description = "This is a test apartment.";

            // Act
            var apartment = new Apartment(partitioning, roomCount, comfort, floor, usefulSurface, buildYear, partitioningId, userId, titlePost, price, addressId, offerType, description);

            // Assert
            apartment.Should().NotBeNull();
            apartment.Partitioning.Should().Be(partitioning);
            apartment.RoomCount.Should().Be(roomCount);
            apartment.Comfort.Should().Be(comfort);
            apartment.Floor.Should().Be(floor);
            apartment.UsefulSurface.Should().Be(usefulSurface);
            apartment.BuildYear.Should().Be(buildYear);
            apartment.PartitioningId.Should().Be(partitioningId);
            apartment.UserId.Should().Be(userId);
            apartment.TitlePost.Should().Be(titlePost);
            apartment.Price.Should().Be(price);
            apartment.AddressId.Should().Be(addressId);
            apartment.OfferType.Should().Be(offerType);
            apartment.Description.Should().Be(description);
        }
    }
}
