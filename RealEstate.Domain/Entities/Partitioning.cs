using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Partitionings")]
    public class Partitioning : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public Partitioning(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<Partitioning> Create(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<Partitioning>.Failure("'Type' must not be empty");

            return Result<Partitioning>.Success(new Partitioning(type));
        }
        public void AttachType(string type)
        {
			Type = type;
		}

    }
}
