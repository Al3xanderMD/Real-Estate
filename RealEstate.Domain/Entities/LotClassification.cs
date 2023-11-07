using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class LotClassification
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public LotClassification(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<LotClassification> CreateLotClassification(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<LotClassification>.Failure("'Type' must not be empty");

            return Result<LotClassification>.Success(new LotClassification(type));
        }
        
    }
}
