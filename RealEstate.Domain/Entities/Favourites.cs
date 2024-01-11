using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Favourites")]
    public class Favourite : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public Guid BasePostId { get; set; }
        public BasePost BasePost { get; set; } = null!;

        public Favourite(Guid userId, Guid basePostId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            BasePostId = basePostId;
        }

        public Favourite(Guid userId, Guid basePostId, BasePost basePost) : this(userId, basePostId)
        {
            BasePost = basePost;
        }

        public static Result<Favourite> Create(Guid userId, Guid basePostId)
        {
            if (userId == Guid.Empty)
                return Result<Favourite>.Failure("'UserId' must not be empty");

            if (basePostId == Guid.Empty)
                return Result<Favourite>.Failure("'BasePostId' must not be empty");

            return Result<Favourite>.Success(new Favourite(userId, basePostId));
        }
    }
}
