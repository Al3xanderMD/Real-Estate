using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("HouseTypes")]
    public class HouseType : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public HouseType(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<HouseType> Create(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<HouseType>.Failure("'Type' must not be empty");

            return Result<HouseType>.Success(new HouseType(type));
        }

        public void AttachType(string type)
        {
			Type = type;
		}

    }
}
