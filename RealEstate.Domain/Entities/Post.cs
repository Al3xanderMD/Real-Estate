using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
	[Table("Posts")]
	public class Post : AuditableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; private set; }
		public Guid PostId { get; private set; }
		public string Type { get; private set; }

		public Post(Guid postId,string type)
		{
			PostId = postId;
			Type = type;
		}

		public void attachType(string type)
		{
			if (!string.IsNullOrWhiteSpace(type)) 
			{
				this.Type = type;
			}
		}

		public void attachPostId(Guid postId)
		{
			if (postId != Guid.Empty)
			{
				this.PostId = postId;
			}
		}

		public static Result<Post> Create(Guid postId, string type)
		{
			if (string.IsNullOrWhiteSpace(type))
				return Result<Post>.Failure("'Type' must not be empty");

			return Result<Post>.Success(new Post(postId, type));
		}

	}
}
