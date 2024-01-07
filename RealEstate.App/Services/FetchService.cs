using Newtonsoft.Json;
using RealEstate.App.Contracts;
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
	}
}
