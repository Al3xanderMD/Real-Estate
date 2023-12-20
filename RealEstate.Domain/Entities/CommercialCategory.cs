using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
	[Table("CommercialCategories")]
	public class CommercialCategory : AuditableEntity
	{
		public Guid Id { get; private set; }
		public string CategoryName { get; private set; }

		public CommercialCategory(string categoryName)
		{
			Id = Guid.NewGuid();
			CategoryName = categoryName;
		}

		public static Result<CommercialCategory> Create(string categoryName)
		{
			if (string.IsNullOrWhiteSpace(categoryName))
				return Result<CommercialCategory>.Failure("Category name is required");

			return Result<CommercialCategory>.Success(new CommercialCategory(categoryName));
		}

		public void AttachCategoryName(string categoryName)
		{
			CategoryName = categoryName;
		}
	}
}