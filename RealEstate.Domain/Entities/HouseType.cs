using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class HouseType
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public HouseType(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<HouseType> CreateHouseType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<HouseType>.Failure("'Type' must not be empty");

            return Result<HouseType>.Success(new HouseType(type));
        }


    }
}
