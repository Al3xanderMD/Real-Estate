using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
	[Table("BasePosts")]
	public class BasePost : AuditableEntity
	{
		public Guid BasePostId { get; set; }
		public string UserId { get; set; } = null!;
		public string TitlePost { get; set; }
		public List<string> Images { get; set; } = new List<string>(); //refacut ultima
		public bool OfferType { get; set; } = false;
		public double Price { get; set; }
		public Guid AddressId { get; set; }
		public Address Address { get; set; } = null!;
		public string Description { get; set; }

		public BasePost(string userId, string titlePost, double price, Guid addressId, bool offerType, string description)
		{
			BasePostId = Guid.NewGuid();
			UserId = userId;
			TitlePost = titlePost;
			Price = price;
			AddressId = addressId;
			OfferType = offerType;
			Description = description;
		}

		public BasePost(string userId, string titlePost, double price, Guid addressId, Address address, bool offerType, string description) 
			: this(userId, titlePost, price, addressId, offerType, description)
		{
			Address = address;
		}

		public static Result<BasePost> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description)
		{
			if (string.IsNullOrWhiteSpace(titlePost))
				return Result<BasePost>.Failure("'TitlePost' must not be empty");
			if (price <= 0)
				return Result<BasePost>.Failure("'Price' must be greater than 0");
			if (addressId == Guid.Empty)
				return Result<BasePost>.Failure("'AddressId' must not be empty");
			if (string.IsNullOrWhiteSpace(description))
				return Result<BasePost>.Failure("'Description' must not be empty");

			return Result<BasePost>.Success(new BasePost(userId, titlePost, price, addressId, offerType, description));
		}

		public void AttachDescription(string description)
		{
			Description = description;
		}
		public void AttachImages(List<string> images)
		{
			Images = images;
		}

		public void AttachAddressId(Guid addressId)
		{
			if (addressId != Guid.Empty)
				AddressId = addressId;
		}
		public void AttachAddress(Address address)
		{
			Address = address;
		}

		public void AttachTitlePost(string titlePost)
		{
			TitlePost = titlePost;
		}

		public void AttachPrice(double price)
		{
			Price = price;
		}

		public void AttachOfferType(bool offerType)
		{
			OfferType = offerType;
		}
	}
}