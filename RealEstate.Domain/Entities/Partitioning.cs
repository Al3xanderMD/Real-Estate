using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Partitioning
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }

        public Partitioning(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }

        public static Result<Partitioning> CreatePartitioning(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Result<Partitioning>.Failure("'Type' must not be empty");

            return Result<Partitioning>.Success(new Partitioning(type));
        }
    }
}
