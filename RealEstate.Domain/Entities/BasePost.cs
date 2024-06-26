﻿using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
	public class BasePost : AuditableEntity
	{
		public Guid BasePostId { get; set; }
		public Guid UserId { get; set; }
		public Client User { get; set; } = null!;
		public string TitlePost { get; set; }
		public List<string> Images { get; set; } = new List<string>();
		public bool OfferType { get; set; } = false;
		public double Price { get; set; }
		public Guid AddressId { get; set; }
		public Address Address { get; set; } = null!;
		public string? Descripion { get; set; } = null;

		public BasePost(Guid userId, string titlePost, double price, Guid addressId, bool offerType)
		{
			BasePostId = Guid.NewGuid();
			UserId = userId;
			TitlePost = titlePost;
			Price = price;
			AddressId = addressId;
			OfferType = offerType;
		}

		private BasePost(Guid userId, string titlePost, double price, Guid addressId, Address address, Client user, bool offerType) : this(userId, titlePost, price, addressId, offerType)
		{
			Address = address;
			User = user;
		}

		public static Result<BasePost> Create(Guid userId, string titlePost, double price, Guid addressId, bool offerType)
		{
			if (string.IsNullOrWhiteSpace(titlePost))
				return Result<BasePost>.Failure("'TitlePost' must not be empty");
			if (price <= 0)
				return Result<BasePost>.Failure("'Price' must be greater than 0");

			return Result<BasePost>.Success(new BasePost(userId, titlePost, price, addressId, offerType));
		}

		public void AttachDescription(string description)
		{
			Descripion = description;
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

		public void AttachUserId(Guid userId)
		{
			UserId = userId;
		}

		public void AttachClient(Client user)
		{
			User = user;
		}
	}
}