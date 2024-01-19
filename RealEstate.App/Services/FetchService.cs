using Newtonsoft.Json;
using RealEstate.App.Contracts;
using RealEstate.App.Models;
using RealEstate.App.Operations.Fetch.Models;
using RealEstate.App.Operations.Fetch.Response;
using System.Net.Http;

namespace RealEstate.App.Services
{

    public class FetchService : IFetchService
    {
		private readonly HttpClient httpClient;

		public FetchService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<List<LotClassificationViewModel>> FetchLotClassificationsAsync()
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/LotClassification");

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("LotClassifications: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApiResponseLot>(jsonString);

				return apiResponse?.LotClassifications;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<CommercialCategoryViewModel>> FetchCommercialCategoriesAsync()
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/CommercialCategories");

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("CommercialCategories: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApiResponseCommercialCategory>(jsonString);

				return apiResponse?.CommercialCategories;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<ApartmentPartitioningViewModel>> FetchApartmentPartitionsAsync()
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/Partitioning");

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Partitionings: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApiResponsePartitionings>(jsonString);

				return apiResponse?.partitionings;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<HouseTypeViewModel>> FetchHouseTypesAsync()
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/HouseType");

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("House types: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApiResponseHouseType>(jsonString);

				return apiResponse?.houseTypes;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<CommercialSpecificViewModel>> FetchCommercialSpecificsAsync()
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/CommercialSpecifics");

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Commercial specifics: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApiResponseCommercialSpecifics>(jsonString);

				return apiResponse?.commercialSpecifics;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<PostResponseViewModel> FetchPostAsync(int id)
		{
			try
			{
				var requestString = "https://localhost:7190/api/v1/Post/"+id.ToString();
				Console.WriteLine("Fetching post: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Post: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<PostResponseViewModel>(jsonString);

				return apiResponse;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<PostResponseViewModel>> FetchPostsAsync(int start, int end) {
			try {
				var requestString = "https://localhost:7190/api/v1/Post?start=" + start.ToString() + "&end=" + end.ToString();
				Console.WriteLine("Fetching posts: " + start.ToString() + " to " + end.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Posts: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<List<PostResponseViewModel>>(jsonString);

				return apiResponse;
			} catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<ApartmentFetchViewModel> FetchApartmentAsync(Guid id)
		{
			try
			{
				var requestString = "https://localhost:7190/api/v1/Apartments/" + id.ToString();
				Console.WriteLine("Fetching apartment: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Apartment fetch: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<ApartmentFetchViewModel>(jsonString);

				return apiResponse;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<HouseFetchViewModel> FetchHouseAsync(Guid id)
		{
			try {
				var requestString = "https://localhost:7190/api/v1/Houses/" + id.ToString();
				Console.WriteLine("Fetching house: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("House fetch: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<HouseFetchViewModel>(jsonString);

				return apiResponse;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<CommercialFetchViewModel> FetchCommercialAsync(Guid id)
		{
			try 
			{
				var requestString = "https://localhost:7190/api/v1/Commercials/" + id.ToString();
				Console.WriteLine("Fetching commercial: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Commercial fetch: " + jsonString);

				var apiResponse = JsonConvert.DeserializeObject<CommercialFetchViewModel>(jsonString);
				
				return apiResponse;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<LotFetchViewModel> FetchLotAsync(Guid id)
		{
			try
			{
				var requestString = "https://localhost:7190/api/v1/Lot/" + id.ToString();
				Console.WriteLine("Fetching lot: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Lot fetch: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<LotFetchViewModel>(jsonString);

				return apiResponse;
			} 
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<HotelPensionFetchViewModel> FetchHotelPensionAsync(Guid id)
		{
			try
			{
				var requestString = "https://localhost:7190/api/v1/HotelPensions/" + id.ToString();
				Console.WriteLine("Fetching hotel pension: " + id.ToString() + " from " + requestString);
				var response = await httpClient.GetAsync(requestString);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Hotel pension fetch: " + jsonString);
				var apiResponse = JsonConvert.DeserializeObject<HotelPensionFetchViewModel>(jsonString);

				return apiResponse;

			} 
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

        public async Task<List<FavouriteFetchViewModel>> FetchFavouritesUserAsync(Guid userId)
        {
			FavouritesResponseViewModel response_obj;
            try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/Favourite/userId/" + userId);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<FavouritesResponseViewModel>(jsonString);

				if (response_obj != null) {
					return response_obj.favourites;
				} else
				{
					Console.WriteLine("Favourites response is null");
					return null;
				}
			} catch (HttpRequestException ex)
			{
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<List<FavouriteFetchViewModel>> FetchUserFavouritePostsAsync(Guid userId)
        {
			FavouritesResponseViewModel response_obj;
            try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/Favourite/userId/" + userId);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();

				response_obj = JsonConvert.DeserializeObject<FavouritesResponseViewModel>(jsonString);

				if (response_obj != null)
				{
					Console.WriteLine("Successfully fetch user posts");
					return response_obj.favourites;
				}
				else 
				{
					Console.WriteLine("Fetching user posts error ");
					return null;
				}
			} catch (HttpRequestException ex)
			{
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

		public async Task<PostResponseViewModel> FetchPostByBasePostIdAsync(Guid id)
		{
            PostResponseViewModel response_obj;
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/Post/basePostId/" + id);

				response.EnsureSuccessStatusCode();

				var jsonString = response.Content.ReadAsStringAsync().Result;

				Console.WriteLine("Post: " + jsonString);

				response_obj = JsonConvert.DeserializeObject<PostResponseViewModel>(jsonString);

				if (response_obj != null)
				{
					return response_obj;
				}
				else
				{
					Console.WriteLine("Fetching post error ");
					return null;
				}
				
			} catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}

		public async Task<List<PostResponseViewModel>> FetchPostsByUserIdAsync(Guid userId)
		{
			try
			{
				var response = await httpClient.GetAsync("https://localhost:7190/api/v1/Post/userId/" + userId);

				response.EnsureSuccessStatusCode();

				var jsonString = await response.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<List<PostResponseViewModel>>(jsonString);

				return apiResponse;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return null;
			}
		}
    }
}
