using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class CommercialCategory
    {
        public Guid IdCategory { get; private set; }
        public string CategoryName { get; private set; }
    
        public CommercialCategory(string categoryName)
        {
            IdCategory = Guid.NewGuid();
            CategoryName = categoryName;
        }

        public Result<CommercialCategory> CreateCommercialCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return Result<CommercialCategory>.Failure("Category name is required");

            return Result<CommercialCategory>.Success(new CommercialCategory(categoryName));
        }
    }
}
