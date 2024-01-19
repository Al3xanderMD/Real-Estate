using RealEstate.App.Models;

namespace RealEstate.App.Operations.Fetch.Models
{
    public class FavouriteFetchViewModel
    {
        public Guid id { get; set; } = Guid.Empty;
        public Guid userId { get; set; } = Guid.Empty;
        public Guid basePostId { get; set; } = Guid.Empty;
        public PostBasePostViewModel basePost { get; set; } = new PostBasePostViewModel();
    }
}
