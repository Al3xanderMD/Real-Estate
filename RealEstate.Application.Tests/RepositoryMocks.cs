using NSubstitute;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests
{
    public class RepositoryMocks
    {
        public static IAddressRepository GetAddressRepository()
       {
           var mockRepository = NSubstitute.Substitute.For<IAddressRepository>();

            var predefinedAddress = new List<Address>
            {
                Address.Create("url1", "address1").Value,
                Address.Create("url2", "address2").Value,
            };
            
            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Address>>.Success(predefinedAddress)));

            return mockRepository;
       }
        public static IClientRepository GetClientRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IClientRepository>();
            var userId1 = new Guid("c78a51a7-01fc-42bd-8c5f-5f5c9c9439a1");
            var userId2 = new Guid("c78a51a7-01fc-42bd-8c5f-5f5c9c9439a2");

            var predefinedClients = new List<Client>
            {
                Client.Create(userId1, "username1", "email1", "name1", "phoneNumber1").Value,
                Client.Create(userId2, "username2", "email2", "name2", "phoneNumber2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Client>>.Success(predefinedClients)));

            return mockRepository;
        }
        public static ICommercialCategoryRepository GetCommercialCategoryRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<ICommercialCategoryRepository>();

            var predefinedCommercialCategories = new List<CommercialCategory>
            {
                CommercialCategory.Create("category1").Value,
                CommercialCategory.Create("category2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<CommercialCategory>>.Success(predefinedCommercialCategories)));

            return mockRepository;
        }
        public static ICommercialSpecificRepository GetCommercialSpecificRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<ICommercialSpecificRepository>();
            var category1 = CommercialCategory.Create("category1").Value;
            var category2 = CommercialCategory.Create("category2").Value;

            var predefinedCommercialSpecifics = new List<CommercialSpecific>
            {
                CommercialSpecific.Create("specific1", category1.Id).Value,
                CommercialSpecific.Create("specific2", category2.Id).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<CommercialSpecific>>.Success(predefinedCommercialSpecifics)));

            return mockRepository;
        }
        public static IHouseTypeRepository GetHouseTypeRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IHouseTypeRepository>();

            var predefinedHouseTypes = new List<HouseType>
            {
                HouseType.Create("type1").Value,
                HouseType.Create("type2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<HouseType>>.Success(predefinedHouseTypes)));

            return mockRepository;
        }
        public static ILotClassificationRepository GetLotClassificationRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<ILotClassificationRepository>();

            var predefinedLotClassifications = new List<LotClassification>
            {
                LotClassification.Create("classification1").Value,
                LotClassification.Create("classification2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<LotClassification>>.Success(predefinedLotClassifications)));

            return mockRepository;
        }
        public static IPartitioningRepository GetPartitioningRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IPartitioningRepository>();

            var predefinedPartitionings = new List<Partitioning>
            {
                Partitioning.Create("partitioning1").Value,
                Partitioning.Create("partitioning2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Partitioning>>.Success(predefinedPartitionings)));

            return mockRepository;
        }
        public static IBasePostRepository GetBasePostRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IBasePostRepository>();
            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();

            var predefinedBasePosts = new List<BasePost>
            {
                BasePost.Create(userId, "titlePost1", 1, address1.Id, true, "description1").Value,
                BasePost.Create(userId, "titlePost2", 2, address2.Id, false, "description2").Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<BasePost>>.Success(predefinedBasePosts)));

            return mockRepository;
        }
        public static IApartmentRepository GetApartmentRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IApartmentRepository>();

            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;
            var partitioning1 = Partitioning.Create("partitioning1").Value;
            var partitioning2 = Partitioning.Create("partitioning2").Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();

            var predefinedApartments = new List<Apartment>
            {
                Apartment.Create(userId, "titlePost1", 1, address1.Id, true, "description1", 1, 1, 1, 1, 2000, partitioning1.Id).Value,
                Apartment.Create(userId, "titlePost2", 2, address2.Id, false, "description2", 2, 2, 2, 2, 2001, partitioning2.Id).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Apartment>>.Success(predefinedApartments)));

            return mockRepository;
        }
        public static IHouseRepository GetHouseRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IHouseRepository>();

            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;
            var houseType1 = HouseType.Create("houseType1").Value;
            var houseType2 = HouseType.Create("houseType2").Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();

            var predefinedHouses = new List<House>
            {
                House.Create(userId, "titlePost1", 1, address1.Id, true, "description1", 1, 1, 1, 1, 2000, houseType1.Id).Value,
                House.Create(userId, "titlePost2", 2, address2.Id, false, "description2", 2, 2, 2, 2, 2001, houseType2.Id).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<House>>.Success(predefinedHouses)));

            return mockRepository;
        }
        public static IHotelPensionRepository GetHotelPensionRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<IHotelPensionRepository>();

            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();

            var predefinedHotelPensions = new List<HotelPension>
            {
                HotelPension.Create(userId, "titlePost1", 1, address1.Id, true, "description1", 1, 1, 1).Value,
                HotelPension.Create(userId, "titlePost2", 2, address2.Id, false, "description2", 2, 2, 2).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<HotelPension>>.Success(predefinedHotelPensions)));

            return mockRepository;
        }
        public static ICommercialRepository GetCommercialRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<ICommercialRepository>();

            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;
            var commercialCategory1 = CommercialCategory.Create("commercialCategory1").Value;
            var commercialCategory2 = CommercialCategory.Create("commercialCategory2").Value;
            var commercialSpecific1 = CommercialSpecific.Create("commercialSpecific1", commercialCategory1.Id).Value;
            var commercialSpecific2 = CommercialSpecific.Create("commercialSpecific2", commercialCategory2.Id).Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();
            DateTime disponibillity1 = new(2024, 1, 1);
            DateTime disponibillity2 = new(2025, 1, 2);

            var predefinedCommercials = new List<Commercial>
            {
                Commercial.Create(userId, "titlePost1", 1, address1.Id, true, "description1", commercialSpecific1.CommercialSpecificId, 1, disponibillity1).Value,
                Commercial.Create(userId, "titlePost2", 2, address2.Id, false, "description2", commercialSpecific2.CommercialSpecificId, 2, disponibillity2).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Commercial>>.Success(predefinedCommercials)));

            return mockRepository;
        }
        public static ILotRepository GetLotRepository()
        {
            var mockRepository = NSubstitute.Substitute.For<ILotRepository>();

            var address1 = Address.Create("url1", "address1").Value;
            var address2 = Address.Create("url2", "address2").Value;
            var lotClassification1 = LotClassification.Create("lotClassification1").Value;
            var lotClassification2 = LotClassification.Create("lotClassification2").Value;

            var userId = new Guid("44444444-4444-4444-4444-444444444444").ToString();

            var predefinedLots = new List<Lot>
            {
                Lot.Create(userId, "titlePost1", 1, address1.Id, true, "description1", 1, 1, lotClassification1.Id).Value,
                Lot.Create(userId, "titlePost2", 2, address2.Id, false, "description2", 2, 2, lotClassification2.Id).Value,
            };

            mockRepository.GetAllAsync().Returns(Task.FromResult(Result<IReadOnlyList<Lot>>.Success(predefinedLots)));

            return mockRepository;
        }
    }
}
