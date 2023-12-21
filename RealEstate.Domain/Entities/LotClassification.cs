using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("LotClassifications")]
    public class LotClassification : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public LotClassification(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<LotClassification> Create(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<LotClassification>.Failure("'Type' must not be empty");

            return Result<LotClassification>.Success(new LotClassification(type));
        }
        public void AttachType(string type)
        {
            Type = type;
        }
    }
}
