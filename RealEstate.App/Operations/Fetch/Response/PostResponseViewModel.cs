using RealEstate.App.Models;

namespace RealEstate.App.Operations.Fetch.Response
{
    public class PostResponseViewModel
    {
        public int id { get; set; }
        public Guid basePostId { get; set; } = Guid.Empty;
        public PostBasePostViewModel basePost { get; set; } = new PostBasePostViewModel();
        public string type { get; set; } = string.Empty;
    }
}
