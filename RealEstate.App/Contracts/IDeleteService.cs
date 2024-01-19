namespace RealEstate.App.Contracts
{
    public interface IDeleteService
    {
        Task DeleteFavouriteAsync(Guid favouriteId);
        Task DeletePostAsync(int postId);
    }
}
