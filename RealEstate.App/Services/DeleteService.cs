using RealEstate.App.Contracts;

namespace RealEstate.App.Services
{
    public class DeleteService : IDeleteService
    {
        private readonly HttpClient httpClient;

        public DeleteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task DeleteFavouriteAsync(Guid favouriteId)
        {
            try
            {
                var response = await httpClient.DeleteAsync("https://localhost:7190/api/v1/Favourite/"+favouriteId);

                response.EnsureSuccessStatusCode();
                
                Console.WriteLine("Favourite deleted : "+favouriteId);

            } catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DeletePostAsync(int postId)
        {
            try
            {
                var response = await httpClient.DeleteAsync("https://localhost:7190/api/v1/Post/"+postId);

                response.EnsureSuccessStatusCode();
                
                Console.WriteLine("Post deleted : "+postId);

            } catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
