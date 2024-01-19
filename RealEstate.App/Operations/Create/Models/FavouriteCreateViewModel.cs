namespace RealEstate.App.Operations.Create.Models
{
    public class FavouriteCreateViewModel
    {
        public Guid userId { get; set; } = Guid.Empty;
        public Guid basePostId { get; set; } = Guid.Empty;
    }
}
