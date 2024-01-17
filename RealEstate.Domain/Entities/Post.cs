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
		public Guid BasePostId { get; private set; }
		public BasePost BasePost { get; private set; }

		public string Type { get; private set; }

		public Post(Guid basePostId,string type)
		{
			BasePostId = basePostId;
			Type = type;
		}

		public Post(Guid basePostId, string type, BasePost basePost) : this(basePostId, type)
		{
            BasePost = basePost;
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
				this.BasePostId = postId;
			}
		}

		public static Result<Post> Create(Guid basePostId, string type)
		{
			if (string.IsNullOrWhiteSpace(type))
				return Result<Post>.Failure("'Type' must not be empty");

			return Result<Post>.Success(new Post(basePostId, type));
		}

	}
}
